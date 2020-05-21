using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MP02.Functional
{
    public class ObjectPlusPlus
    {
        private Dictionary<IAsocjacja, Dictionary<object, ObjectPlusPlus>> links = new Dictionary<IAsocjacja, Dictionary<object, ObjectPlusPlus>>();
        private static HashSet<ObjectPlusPlus> allParts = new HashSet<ObjectPlusPlus>();

        public ObjectPlusPlus() : base()
        {

        }

        private void addLink(IAsocjacja roleName, ObjectPlusPlus targetObject, object qualifier, int counter)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;
            if (!roleName.verifyInstance(this, targetObject)) throw new Exception("obiekty nie pasuja do danej asocjacji");

            if (counter < 1)
            {
                return;
            }


            if (targetObject.containsRole(roleName.getOpposite()))
            {
                if (roleName.getOpposite().getMaxCardinality() != 0 && counter == 2 && !(targetObject.roleSize(roleName.getOpposite()) < roleName.getOpposite().getMaxCardinality()))
                    throw new Exception("Maksymalna licznosc w  " + GetType().Name + " osiagnieta ma juz powiazane: " + targetObject.roleSize(roleName.getOpposite()) + " obiektow");
            }

            if (links.ContainsKey(roleName))
            {
                objectLinks = links[roleName];
                if (roleName.getMaxCardinality() != 0 && !(objectLinks.Count < roleName.getMaxCardinality()))
                    throw new Exception("Maksymalna licznosc osiagnieta  " + GetType().Name + "  ma juz powiazane: " + this.roleSize(roleName) + " obiektow");
            }

            else
            {
                objectLinks = new Dictionary<object, ObjectPlusPlus>();
                links.Add(roleName, objectLinks);
            }
            if (!objectLinks.ContainsKey(qualifier))
            {
                objectLinks.Add(qualifier, targetObject);

                targetObject.addLink(roleName.getOpposite(), this, this, counter - 1);
            }
        }

        public void addLink(IAsocjacja roleName, ObjectPlusPlus targetObject, object qualifier)
        {
            addLink(roleName, targetObject, qualifier, 2);
        }

        public void addLink(IAsocjacja roleName, ObjectPlusPlus targetObject)
        {
            addLink(roleName, targetObject, targetObject);
        }

        public void addPart(IAsocjacja roleName, ObjectPlusPlus partObject)
        {
            if (allParts.Contains(partObject))
            {
                throw new Exception("The part is already connected to a whole!");
            }

            addLink(roleName, partObject);
            allParts.Add(partObject);
        }



        public ObjectPlusPlus[] getLinks(IAsocjacja roleName)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (!links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }
            objectLinks = links[roleName];

            return objectLinks.Values.ToArray();
        }



        public void showLinks(IAsocjacja roleName, StreamWriter stream)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (!links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }

            objectLinks = links[roleName];

            var col = objectLinks.Values;

            stream.WriteLine(GetType().Name + " links, role '" + roleName + "':");

            foreach (object obj in col)
            {
                stream.WriteLine("   " + obj);
            }
        }



        public ObjectPlusPlus getLinkedObject(IAsocjacja roleName, object qualifier)
        {
            Dictionary<object, ObjectPlusPlus> objectLinks;

            if (!links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }

            objectLinks = links[roleName];
            if (!objectLinks.ContainsKey(qualifier))
            {
                throw new Exception("No link for the qualifer: " + qualifier);
            }

            return objectLinks[qualifier];
        }



        public bool containsRole(IAsocjacja roleName)
        {
            return links.ContainsKey(roleName);
        }

        public int roleSize(IAsocjacja roleName)
        {
            if (!containsRole(roleName)) throw new Exception("Can't get size, No links for the role: " + roleName);
            return links[roleName].Count;
        }



        private void removeLink(IAsocjacja roleName, ObjectPlusPlus targetObject, object qualifier, int counter)
        {
            if (counter < 1) return;
            Dictionary<object, ObjectPlusPlus> objectLinks;
            if (!links.ContainsKey(roleName))
            {
                throw new Exception("No links for the role: " + roleName);
            }
            objectLinks = links[roleName];
            if (objectLinks.ContainsKey(qualifier))
            {
                objectLinks.Remove(qualifier);
                targetObject.removeLink(roleName.getOpposite(), this, this, counter - 1);
            }

            objectLinks.Remove(targetObject);
            targetObject.removeLink(roleName.getOpposite(), this, qualifier, counter - 1);

        }



        public void removeLink(IAsocjacja roleName, ObjectPlusPlus targetObject, object qualifier)
        {
            removeLink(roleName, targetObject, qualifier, 2);
        }

        public void removeLink(IAsocjacja roleName, ObjectPlusPlus targetObject)
        {
            removeLink(roleName, targetObject, targetObject, 2);
        }

        public void removePart(IAsocjacja roleName, ObjectPlusPlus targetObject)
        {
            targetObject.removeObject();
            allParts.Remove(targetObject);
        }

        //override
        public void removeObject()
        {

            foreach (var link in links)
            {
                Dictionary<object, ObjectPlusPlus> objectLinks = link.Value;


                foreach (var objLink in objectLinks)
                {
                    try
                    {
                        removeLink(link.Key, objLink.Value, objLink.Value);
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
            removeObject();
        }


    }
}
