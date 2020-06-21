namespace Projekt_Koncowy_GUI.Models
{
    public class PartialLicense
    {
        public int PartialLicenseId { get; set; }

        public int LicenseId { get; set; }
        public License License { get; set; }
    }
}
