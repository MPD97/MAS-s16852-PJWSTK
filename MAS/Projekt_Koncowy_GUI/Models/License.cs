using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class License
    {
        public int LicenseId { get; set; }

        public DateTime ExpireDate { get; set; }
        public DateTime BuyDate { get; set; }
        public decimal Price { get; set; }

        public ICollection<FullLicense> FullLicenses { get; set; }

        public ICollection<PartialLicense> PartialLicenses { get; set; }

        public int EndpointDeviceId { get; set; }
        public EndpointDevice EndpointDevice { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
