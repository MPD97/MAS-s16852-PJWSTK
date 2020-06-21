using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class User
    {
        public int UserId { get; set; }

        public int LicenseId { get; set; }
        public License License { get; set; }

        public UserAdministrator UsersAdministrator { get; set; }
        public UserNormal UserNormal { get; set; }

    }
    public class UserAdministrator
    {
        public int UserAdministratorId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
    public class UserNormal
    {
        public int UserNormalId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
