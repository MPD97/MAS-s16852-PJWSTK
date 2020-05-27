using MP03.Functional;
using System;

namespace MP03
{
    public class Employee : ObjectPlusPlus
    {
        public DateTime BirthDate { get; set; }

        public Employee(DateTime birthDate) : base()
        {
            BirthDate = birthDate;
        }

        public Employee(IAssociation roleName, DateTime birthDate, string specialization) : base()
        {
            BirthDate = birthDate;

            if (roleName == null)
            {
                throw new Exception("Rola nie moze byc null.");
            }
        }

        public Employee(IAssociation roleName, DateTime birthDate, bool forkliftLicense) : base()
        {
            BirthDate = birthDate;

            if (roleName == null)
            {
                throw new Exception("Rola nie moze byc null.");
            }
        }

        private void AddServiceman()
        {

        }
        private void AddStorekeeper()
        {

        }
    }
} 
