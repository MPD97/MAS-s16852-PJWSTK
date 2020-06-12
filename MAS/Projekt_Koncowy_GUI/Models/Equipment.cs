using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        public int Amount { get; set; }


        public string ComponentId { get; set; }
        public int EndpointDeviceId { get; set; }

        public Component Component { get; set; }
        public EndpointDevice EndpointDevice { get; set; }
    }
}
