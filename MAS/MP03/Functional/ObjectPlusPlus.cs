using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MP02.Functional
{
    public class ObjectPlusPlus : ObjectPlus
    {
        private Dictionary<IAssociation, Dictionary<object, ObjectPlusPlus>> Links = new Dictionary<IAssociation, Dictionary<object, ObjectPlusPlus>>();
        private static HashSet<ObjectPlusPlus> AllParts = new HashSet<ObjectPlusPlus>();

        public ObjectPlusPlus() : base()
        {

        }

        private void AddLink(IAssociation roleName, ObjectPlusPlus targetObject, object qualifier, int counter)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;
            if (roleName.VerifyInstance(this,targetObject) == false) 
                throw new Exception("obiekty nie pasuja do podanej asocjacji.");

            if (counter < 1)
            {
                return;
            }

            if (targetObject.ContainsRole(roleName.GetOposite()))
            {
                if (roleName.GetOposite().GetMaxCardinality() != 0 && counter == 2 && !(targetObject.RoleSize(roleName.GetOposite()) < roleName.GetOposite().GetMaxCardinality()))
                    throw new Exception($"Maksymalna licznosc w {roleName.Class2.Name} osiagnieta i ma juz powiazane maksymalne: {targetObject.RoleSize(roleName.GetOposite())} obiektow typu {GetType().Name}.");
            }

            if (Links.ContainsKey(roleName))
            {
                objectLinks = Links[roleName];
                if (roleName.GetMaxCardinality() != 0 && !(objectLinks.Count < roleName.GetMaxCardinality()))
                    throw new Exception($"Maksymalna licznosc w {GetType().Name} osiagnieta i juz powiazane maksymalne: {RoleSize(roleName)} obiektow typu {roleName.Class2.Name}.");
            }
            else
            {
                objectLinks = new Dictionary<object, ObjectPlusPlus>();
                Links.Add(roleName, objectLinks);
            }

            if (objectLinks.ContainsKey(qualifier) == false)
            {
                objectLinks.Add(qualifier, targetObject);

                targetObject.AddLink(roleName.GetOposite(), this, this, counter - 1);
            }
        }

        public void AddLink(IAssociation roleName, ObjectPlusPlus targetObject, object qualifier)
        {
            AddLink(roleName, targetObject, qualifier, 2);
        }

        public void AddLink(IAssociation roleName, ObjectPlusPlus targetObject)
        {
            AddLink(roleName, targetObject, targetObject);
        }

        internal T AddPart<T>(IAssociation roleName, T partObject) where T : ObjectPlusPlus
        {
            if (AllParts.Contains(partObject))
            {
                throw new Exception($"Czesc: {partObject.GetType().Name} wchodzi juz w sklad obiektu-calosc: {GetType().Name}.");
            }

            AddLink(roleName, partObject);
            AllParts.Add(partObject);
            
            return partObject;
        }

        public ObjectPlusPlus[] GetLinks(IAssociation roleName)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (Links.ContainsKey(roleName) == false)
            {
                throw new Exception("Brak powiazan dla relacji: " + roleName);
            }
            objectLinks = Links[roleName];

            return objectLinks.Values.ToArray();
        }

        public void ShowLinks(IAssociation roleName, StreamWriter stream)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (Links.ContainsKey(roleName) == false)
            {
                throw new Exception("Brak powiazan dla relacji: " + roleName);
            }

            objectLinks = Links[roleName];

            var col = objectLinks.Values;

            stream.WriteLine($"Wyswietlam powiazania dla klasy: {GetType().Name}\r\n{roleName}:");

            foreach (object obj in col)
            {
                stream.WriteLine((obj as ObjectPlusPlus).ToStringJSON());
            }
        }

        public ObjectPlusPlus GetLinkedObject(IAssociation roleName, object qualifier)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (Links.ContainsKey(roleName) == false)
            {
                throw new Exception("Asocjacja nie istnieje: " + roleName);
            }

            objectLinks = Links[roleName];
            if (objectLinks.ContainsKey(qualifier) == false)
            {
                throw new Exception("Brak isnitjacych powiazan kwalifikowanych dla: " + qualifier);
            }

            return objectLinks[qualifier];
        }

        public bool ContainsRole(IAssociation roleName)
        {
            return Links.ContainsKey(roleName);
        }

        public int RoleSize(IAssociation roleName)
        {
            if (ContainsRole(roleName) == false) 
                throw new Exception("Nie moge pobrac rozmiaru relacji z uwagi na brak asocjacji: " + roleName);
            return Links[roleName].Count;
        }

        private void RemoveLink(IAssociation roleName, ObjectPlusPlus targetObject, object qualifier, int counter)
        {
            if (counter < 1) return;
            Dictionary<object, ObjectPlusPlus> objectLinks;
            if (Links.ContainsKey(roleName) == false)
            {
                throw new Exception("Brak powiazan z rola: " + roleName);
            }
            objectLinks = Links[roleName];
            if (objectLinks.ContainsKey(qualifier))
            {
                objectLinks.Remove(qualifier);
                targetObject.RemoveLink(roleName.GetOposite(), this, this, counter - 1);
            }

            objectLinks.Remove(targetObject);
            targetObject.RemoveLink(roleName.GetOposite(), this, qualifier, counter - 1);
        }


        public void RemoveLink(IAssociation roleName, ObjectPlusPlus targetObject, object qualifier)
        {
            RemoveLink(roleName, targetObject, qualifier, 2);
        }

        public void RemoveLink(IAssociation roleName, ObjectPlusPlus targetObject)
        {
            RemoveLink(roleName, targetObject, targetObject, 2);
        }

        public void RemovePart(IAssociation roleName, ObjectPlusPlus targetObject)
        {
            targetObject.RemoveObject();
            AllParts.Remove(targetObject);
        }

        public void RemoveObject() 
        {
            foreach (var link in Links)
            {
                Dictionary<object, ObjectPlusPlus> objectLinks = link.Value;

                foreach (var objLink in objectLinks)
                {
                    try
                    {
                        RemoveLink(link.Key, objLink.Value, objLink.Value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
        // TODO: Usuwanie z extensji
    }
}
