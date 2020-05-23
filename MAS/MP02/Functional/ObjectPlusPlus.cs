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
            if (!roleName.VerifyInstance(this, targetObject)) throw new Exception("obiekty nie pasuja do danej asocjacji");

            if (counter < 1)
            {
                return;
            }

            if (targetObject.ContainsRole(roleName.GetOposite()))
            {
                if (roleName.GetOposite().GetMaxCardinality() != 0 && counter == 2 && !(targetObject.RoleSize(roleName.GetOposite()) < roleName.GetOposite().GetMaxCardinality()))
                    throw new Exception("Maksymalna licznosc w  " + GetType().Name + " osiagnieta ma juz powiazane: " + targetObject.RoleSize(roleName.GetOposite()) + " obiektow");
            }

            if (Links.ContainsKey(roleName))
            {
                objectLinks = Links[roleName];
                if (roleName.GetMaxCardinality() != 0 && !(objectLinks.Count < roleName.GetMaxCardinality()))
                    throw new Exception("Maksymalna licznosc osiagnieta  " + GetType().Name + "  ma juz powiazane: " + this.RoleSize(roleName) + " obiektow");
            }
            else
            {
                objectLinks = new Dictionary<object, ObjectPlusPlus>();
                Links.Add(roleName, objectLinks);
            }

            if (!objectLinks.ContainsKey(qualifier))
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

        public void AddPart(IAssociation roleName, ObjectPlusPlus partObject)
        {
            if (AllParts.Contains(partObject))
            {
                throw new Exception("The part is already connected to a whole!");
            }

            AddLink(roleName, partObject);
            AllParts.Add(partObject);
        }

        public ObjectPlusPlus[] GetLinks(IAssociation roleName)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (!Links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }
            objectLinks = Links[roleName];

            return objectLinks.Values.ToArray();
        }



        public void ShowLinks(IAssociation roleName, StreamWriter stream)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (!Links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }

            objectLinks = Links[roleName];

            var col = objectLinks.Values;

            stream.WriteLine(GetType().Name + " links, role '" + roleName + "':");

            foreach (object obj in col)
            {
                stream.WriteLine("   " + obj);
            }
        }



        public ObjectPlusPlus GetLinkedObject(IAssociation roleName, object qualifier)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (!Links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }

            objectLinks = Links[roleName];
            if (!objectLinks.ContainsKey(qualifier))
            {
                throw new Exception("No link for the qualifer: " + qualifier);
            }

            return objectLinks[qualifier];
        }

        public bool ContainsRole(IAssociation roleName)
        {
            return Links.ContainsKey(roleName);
        }

        public int RoleSize(IAssociation roleName)
        {
            if (!ContainsRole(roleName)) throw new Exception("Can't get size, No links for the role: " + roleName);
            return Links[roleName].Count;
        }

        private void RemoveLink(IAssociation roleName, ObjectPlusPlus targetObject, object qualifier, int counter)
        {
            if (counter < 1) return;
            Dictionary<object, ObjectPlusPlus> objectLinks;
            if (!Links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
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

        //override
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
            //links.entrySet().iterator().forEachRemaining(entry => {
            //    Dictionary<object, ObjectPlusPlus> objectLinks = entry;

            //    objectLinks.entrySet().iterator().forEachRemaining(innerEntry => {
            //        try
            //        {
            //            this.removeLink(entry.getKey(), innerEntry.getValue(), innerEntry.getKey());
            //        }
            //        catch (Exception e)
            //        {
            //            e.printStackTrace();
            //        }
            //    });

            //});
            RemoveObject();
        }


    }
}
