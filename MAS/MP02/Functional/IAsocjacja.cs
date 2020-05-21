namespace MP02.Functional
{
    public interface IAsocjacja
    {
        public bool verifyInstance<X, Y>(X o1, Y o2);

        public IAsocjacja getOpposite();

        public int getMaxCardinality();
    }
}