using System.Collections.Generic;

namespace Projekt_Koncowy_GUI.Models
{
    public class GPSModule
    {
        public int GPSModuleId { get; set; }

        public int AddOnModuleId { get; set; }
        public AddOnModule AddOnModule { get; set; }

        public ICollection<SupportedSattelites> SupportedSatellites { get; set; }   // Atrybut powtarzalny
    }
}
