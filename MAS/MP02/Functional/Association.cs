using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP02.Functional
{
    public class Association<T, R> : IAssociation where T : ObjectPlusPlus where R : ObjectPlusPlus
    {
        public string Name { get; set; }
        public ObjectPlusPlus Class1 { get; set; }
        public ObjectPlusPlus Class2 { get; set; }
        private Association<R, T> OppositeAssociationEnd { get; set; }
        private int MaximumCardinality { get; set; }

        private static HashSet<IAssociation> AllAssociations { get; set; } = new HashSet<IAssociation>();


        private Association(T class1, R class2, int maxCardinalityClass, string name)
        {
            Name = name;
            Class1 = class1;
            Class2 = class2;
            MaximumCardinality = maxCardinalityClass;
        }

        public static bool CreateAssociation<X, Y>(T class1, R class2, int maxCardinalityClass1, int maxCardinalityClass2) 
            where X : IObjectPlusPlus where Y : IObjectPlusPlus
        {
            bool exists = AllAssociations.Any(obj =>
                obj.Class1.Equals(class1) &&
                obj.Class2.Equals(class2) &&
                obj.GetMaxCardinality() == maxCardinalityClass2 && obj.Name == null);

            if (exists)
            { 
                return false; 
            }

            Association<T, R> o = new Association<T, R>(class1, class2, maxCardinalityClass2, null);
            o.OppositeAssociationEnd = new Association<R, T>(class2, class1, maxCardinalityClass1, null);
            o.OppositeAssociationEnd.OppositeAssociationEnd = o;
            AllAssociations.Add(o);

            AllAssociations.Add(o.OppositeAssociationEnd);
            return true;

        }

    

        public static bool CreateAssociation<X, Y>(T class1, R class2, int maxCardinalityClass1, int maxCardinalityClass2, string name, string reverseName) where X : ObjectPlusPlus where Y : ObjectPlusPlus

        {

            bool exists = AllAssociations.Any(obj =>
                    obj.Class1.Equals(class1) &&
                    obj.Class2.Equals(class2) &&
                    obj.GetMaxCardinality() == maxCardinalityClass2 &&
                    obj.Name == name);

            if (exists) return false;

            Association<T, R> o = new Association<T, R>(class1, class2, maxCardinalityClass2, name);
            o.OppositeAssociationEnd = new Association<R, T>(class2, class1, maxCardinalityClass1, reverseName);
            o.OppositeAssociationEnd.OppositeAssociationEnd = o;
            AllAssociations.Add(o);

            AllAssociations.Add(o.OppositeAssociationEnd);
            return true;

        }

        public static Association<T, R> GetAssociation<X, Y>(T class1, R class2) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return (Association<T, R>)AllAssociations.Where(obj => obj.Class1
                   .Equals(class1) && obj.Class2.Equals(class2)).FirstOrDefault();
        }


        public static Association<T, R> GetAssociation<X, Y>(T class1, R class2, string name) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return (Association<T, R>) AllAssociations.Where(obj => obj.Class1
                            .Equals(class1) && obj.Class2.Equals(class2) && obj.Name == name)
                .FirstOrDefault();
        }

        public bool VerifyInstance<X, Y>(X o1, Y o2) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return Class1.GetType() == o1.GetType() && Class2.GetType() == o2.GetType();

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
            return "Asocjacja [class1=" + Class1 + ", class2=" + Class2 + ", name=" + Name + "]" + ", Opposite Asocjacja [class1=" + OppositeAssociationEnd.Class1 + ", class2=" + OppositeAssociationEnd.Class2 + ", name=" + OppositeAssociationEnd.Name + "]";
        }
    }
}
