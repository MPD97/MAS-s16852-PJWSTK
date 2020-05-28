using System;

namespace MP03
{
    public class GPSModule : AddOnModule, IGPSModule
    {
        public string[] SupportedSatellites { get; set; }   // Atrybut powtarzalny

        public GPSModule(string[] supportedSatellites) : base()
        {
            SupportedSatellites = supportedSatellites;
        }

        public string GetAmoutOfConnectedDevices()
        {
            return $"Polaczono z {new Random().Next(0, 30)} Satelitami GPS.";
        }
    }
} 
