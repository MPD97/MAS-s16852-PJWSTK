using MP03.Functional;
using System;

namespace MP03
{
    public class AllInOneModule : BluetoothModule, IGPSModule
    {

        public AllInOneModule(IAssociation roleNameGPSModule, string transmisionVersion, string[] supportedSatellites) : base(transmisionVersion)
        {
            AddGPSModule(roleNameGPSModule, supportedSatellites);
        }

        private void AddGPSModule(IAssociation roleNameGPSModule, string[] supportedSatellites)
        {
            if (roleNameGPSModule == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            AddPart(roleNameGPSModule, new GPSModule(supportedSatellites));
        }

        public string GetAmoutOfConnectedDevices()
        {
            return $"Polaczono z {new Random().Next(0, 30)} Satelitami GPS oraz z {new Random().Next(0, 30)} urzadzeniami Bluetooth.";
        }
    }
}
