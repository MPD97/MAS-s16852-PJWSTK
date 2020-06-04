using MP03.Functional;

namespace MP03
{
    public class CommunicationModule : ObjectPlusPlus
    {
        public int Frequency { get; set; }
        public string IMEI { get; set; }
        public string Model { get; set; }
        public long? SerialNumber { get; set; }     // Atrybut opcjonalny

        public CommunicationModule(int frequency, string iMEI, string model, long? serialNumber) : base()
        {
            Frequency = frequency;
            IMEI = iMEI;
            Model = model;
            SerialNumber = serialNumber;
        }
    }
}
