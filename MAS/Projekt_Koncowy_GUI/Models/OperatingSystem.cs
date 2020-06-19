using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class OperatingSystem
    {

        public int OperatingSystemId { get; set; }

        public string Version { get; set; }
        public string Type { get; set; }

        public ICollection<EndpointDevice> EndpointDevices { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }

        public ICollection<Function> Functions { get; set; }


        public void Update()                                // Metoda
        {

        }
        public void Update(string version)                  // Przeciążenie metody
        {

        }
    }
}
