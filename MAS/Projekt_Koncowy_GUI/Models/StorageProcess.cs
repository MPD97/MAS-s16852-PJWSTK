using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class StorageProcess 
    {
        public int StorageProcessId { get; set; }
        public DateTime PlacementDate { get; set; }
        public bool FromReturn { get; set; }

        public int EndpointDeviceId { get; set; }
        public EndpointDevice EndpointDevice { get; set; }


        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
