namespace Projekt_Koncowy_GUI.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public int LicenseId { get; set; }
        public License License { get; set; }
    }
}
