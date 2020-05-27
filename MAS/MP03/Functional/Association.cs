using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP02.Functional
{
    public class Association<T, R> : IAssociation where T : ObjectPlusPlus where R : ObjectPlusPlus
    {
        public string Name { get; set; }
        public Type Class1 { get; set; }
        public Type Class2 { get; set; }
        private Association<R, T> OppositeAssociationEnd { get; set; }
        private int MaximumCardinality { get; set; }

        private static HashSet<IAssociation> AllAssociations { get; set; } = new HashSet<IAssociation>();


        private Association(int maxCardinalityClass, string name)
        {
            Name = name;
            Class1 = typeof(T);
            Class2 = typeof(R);
            MaximumCardinality = maxCardinalityClass;
        }

        public static bool CreateAssociation(int maxCardinalityClass1, int maxCardinalityClass2)
        {
            bool exists = AllAssociations.Any(obj =>
                obj.Class1.Equals(typeof(T)) &&
                obj.Class2.Equals(typeof(R)) &&
                obj.GetMaxCardinality() == maxCardinalityClass2 && obj.Name == null);

            if (exists)
            {
                return false;
            }

            Association<T, R> o = new Association<T, R>(maxCardinalityClass2, null);
            o.OppositeAssociationEnd = new Association<R, T>(maxCardinalityClass1, null);
            o.OppositeAssociationEnd.OppositeAssociationEnd = o;
            AllAssociations.Add(o);

            AllAssociations.Add(o.OppositeAssociationEnd);
            return true;

        }



        public static bool CreateAssociation(int maxCardinalityClass1, int maxCardinalityClass2, string name, string reverseName) 
        {

            bool exists = AllAssociations.Any(obj =>
                    obj.Class1.Equals(typeof(T)) &&
                    obj.Class2.Equals(typeof(R)) &&
                    obj.GetMaxCardinality() == maxCardinalityClass2 &&
                    obj.Name == name);

            if (exists) return false;

            Association<T, R> o = new Association<T, R>(maxCardinalityClass2, name);
            o.OppositeAssociationEnd = new Association<R, T>(maxCardinalityClass1, reverseName);
            o.OppositeAssociationEnd.OppositeAssociationEnd = o;
            AllAssociations.Add(o);

            AllAssociations.Add(o.OppositeAssociationEnd);
            return true;
        }

        public static Association<T, R> GetAssociation() 
        {
            return (Association<T, R>)AllAssociations.Where(obj => obj.Class1
                   .Equals(typeof(T)) && obj.Class2.Equals(typeof(R))).FirstOrDefault();
        }


        public static Association<T, R> GetAssociation(string name) 
        {
            return (Association<T, R>)AllAssociations.Where(obj => obj.Class1
                           .Equals(typeof(T)) && obj.Class2.Equals(typeof(R)) && obj.Name == name)
                .FirstOrDefault();
        }

        public bool VerifyInstance<X, Y>(X o1, Y o2) 
            where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return Class1 == o1.GetType() && Class2 == o2.GetType();
        }

        public IAssociation GetOposite()
        {
            return OppositeAssociationEnd;
        }

        public int GetMaxCardinality()
        {
            return MaximumCardinality;
        }

        public override string ToString()
        {
            return $"Asocjacja miedzy [{Class1.Name}], a [{Class2.Name}] o nazwie [{Name}].\r\nPrzeciwna Asocjacja miedzy [{GetOposite().Class1.Name}], a [{GetOposite().Class2.Name}] o nazwie [{GetOposite().Name}].\r\n";
        }

       
    }
}
