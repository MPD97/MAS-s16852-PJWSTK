namespace Projekt_Koncowy_GUI.Models
{
    public class SupportedSattelites
    {
        public int SupportedSattelitesId { get; set; }

        public int GPSModuleId { get; set; }
        public GPSModule GPSModules { get; set; }
    }
}
