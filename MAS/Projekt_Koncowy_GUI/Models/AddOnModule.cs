using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class AddOnModule
    {
        public int AddOnModuleId { get; set; }


        public int EndpointDeviceId { get; set; }
        public EndpointDevice EndpointDevice { get; set; }

        public ICollection<GPSModule> GPSModules { get; set; }
        public ICollection<BluetoothModule> BluetoothModules { get; set; }

    }
}
