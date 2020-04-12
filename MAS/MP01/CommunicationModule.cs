namespace MP01
{
    public class CommunicationModule : ObjectPlus
    {
        public int Frequency { get; set; }
        public string IMEI { get; set; }
        public string Model { get; set; }
        public long? SerialNumber { get; set; }     // Atrybut opcjonalny
    }
}
