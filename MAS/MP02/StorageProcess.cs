using System;

namespace MP02
{
    public class StorageProcess : ObjectPlus
    {
        public StorageProcess() : base()
        {

        }
        public DateTime PlacementDate { get; set; }
        public bool FromReturn { get; set; }
    }
}
