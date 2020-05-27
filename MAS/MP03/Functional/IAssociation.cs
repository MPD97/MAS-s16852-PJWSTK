using System;

namespace MP03.Functional
{
    public interface IAssociation
    {
        public bool VerifyInstance<T, R>(T o1, R o2) where T : ObjectPlusPlus where R : ObjectPlusPlus;

        public IAssociation GetOposite();

        public int GetMaxCardinality();

        public string Name { get; set; }
        public Type Class1 { get; set; }
        public Type Class2 { get; set; }
    }
}