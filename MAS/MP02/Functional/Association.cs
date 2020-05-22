using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP02.Functional
{
    public class Association<T, R> : IAssociation where T : ObjectPlusPlus where R : ObjectPlusPlus
    {
        private string name;
        private T class1;
        private R class2;
        private Association<R, T> opposite;
        int maxCardinalityClass;
        
        private static HashSet<Association<ObjectPlusPlus, ObjectPlusPlus>> associationSet = new HashSet<Association<ObjectPlusPlus, ObjectPlusPlus>>();

        private Association(T class1, R class2, int maxCardinalityClass, string name)
        {
            this.name = name;
            this.class1 = class1;
            this.class2 = class2;
            this.maxCardinalityClass = maxCardinalityClass;
        }

        public static bool createAssociation<X, Y>(X class1, Y class2, int maxCardinalityClass1, int maxCardinalityClass2) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            bool exists = associationSet.Any(obj =>
                obj.class1.Equals(class1) &&
                obj.class2.Equals(class2) &&
                obj.getMaxCardinality() == maxCardinalityClass2 && obj.name == null);

            if (exists)

            { return false; }

            Association<X ,Y> o = new Association<X, Y>(class1, class2, maxCardinalityClass2, null);
            o.opposite = new Association<Y, X>(class2, class1, maxCardinalityClass1, null);
            o.opposite.opposite = o;
            associationSet.Add(o);
            associationSet.Add(o.opposite);
            return true;

        }

        public static bool createAssociation<X, Y>(X class1, Y class2, int maxCardinalityClass1, int maxCardinalityClass2, string name, string reverseName) where X : ObjectPlusPlus where Y : ObjectPlusPlus

        {

            bool exists = associationSet.Any(obj =>
                    obj.class1.Equals(class1) &&
                    obj.class2.Equals(class2) &&
                    obj.getMaxCardinality() == maxCardinalityClass2 &&
                    obj.name.Equals(name));

            if (exists) return false;

            Association<X, Y> o = new Association<X, Y>(class1, class2, maxCardinalityClass2, name);
            o.opposite = new Association<Y, X>(class2, class1, maxCardinalityClass1, reverseName);
            o.opposite.opposite = o;
            associationSet.Add(o);

            associationSet.Add(o.opposite);
            return true;

        }

        public static Association<X, Y> getAssociation<X, Y>(X class1, Y class2) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return associationSet.Where(obj => obj.getClass1()
                   .Equals(class1) && obj.getClass2().Equals(class2)).FirstOrDefault();
        }



        public static Association<X, Y> getAssociation<X, Y>(X class1, Y class2, string name) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return associationSet.Where(obj => obj.getClass1()
                            .Equals(class1) && obj.getClass2().Equals(class2) && obj.name.Equals(name))
                .FirstOrDefault();
        }


        public bool verifyInstance<X, Y>(X o1, Y o2) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return class1.GetType() == o1.GetType() && class2.GetType() == o2.GetType();

        }


        public IAssociation getOpposite()
        {
            return opposite;
        }


        public int getMaxCardinality()
        {
            return maxCardinalityClass;
        }

        public T getClass1()
        {
            return class1;
        }

        public R getClass2()
        {
            return class2;
        }


        public override string ToString()
        {
            return "Asocjacja [class1=" + class1 + ", class2=" + class2 + ", name=" + name + "]" + ", Opposite Asocjacja [class1=" + opposite.class1 + ", class2=" + opposite.class2 + ", name=" + opposite.name + "]";
        }
    }
}
