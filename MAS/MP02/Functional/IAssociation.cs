namespace MP02.Functional
{
    public interface IAssociation
    {
        public bool verifyInstance<X, Y>(X o1, Y o2) where X : ObjectPlusPlus where Y : ObjectPlusPlus;

        public IAssociation getOpposite();

        public int getMaxCardinality();
    }
}