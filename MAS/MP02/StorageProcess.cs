using MP02.Functional;

namespace MP02
{
    public class StorageProcess : ObjectPlusPlus
    {
        public StorageProcess() : base()
        {

        }
        public DateTime PlacementDate { get; set; }
        public bool FromReturn { get; set; }
    }
}
