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

        public FullLicense FullLicense { get; set; }

        public PartialLicense PartialLicense { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
