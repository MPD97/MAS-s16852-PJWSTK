using Projekt_Koncowy_GUI.Models;
using System.Collections;
using System.Collections.Generic;

namespace Projekt_Koncowy_GUI.Models
{
    public class CommunicationModule
    {
        public string IMEI { get; set; }
        public int Frequency { get; set; }
        public string Model { get; set; }
        public long? SerialNumber { get; set; }     // Atrybut opcjonalny

        public ICollection<EndpointDevice> EndpointDevices { get; set; }
    }
}
