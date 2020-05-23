namespace MP02.Functional
{
    public interface IAssociation
    {
        public bool VerifyInstance<X, Y>(X o1, Y o2) where X : ObjectPlusPlus where Y : ObjectPlusPlus;

        public IAssociation GetOposite();

        public int GetMaxCardinality();

        public string Name { get; set; }
        public ObjectPlusPlus Class1 { get; set; }
        public ObjectPlusPlus Class2 { get; set; }
    }
}