using MP03.Functional;
using System;

namespace MP03
{
    public class StorageProcess : ObjectPlusPlus
    {
        public StorageProcess() : base()
        {

        }
        public StorageProcess(DateTime placementDate, bool fromReturn) : base()
        {
            PlacementDate = placementDate;
            FromReturn = fromReturn;
        }
        public DateTime PlacementDate { get; set; }
        public bool FromReturn { get; set; }
    }
}
