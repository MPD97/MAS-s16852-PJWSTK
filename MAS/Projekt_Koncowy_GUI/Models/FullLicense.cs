namespace Projekt_Koncowy_GUI.Models
{
    public class FullLicense
    {
        public int FullLicenseId { get; set; }
        public string CardNumber { get; set; }

        public int LicenseId { get; set; }
        public License License { get; set; }
    }
}
