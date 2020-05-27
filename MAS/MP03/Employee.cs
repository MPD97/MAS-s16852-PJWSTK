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

        public Employee(IAssociation roleNameServiceman, DateTime birthDate, string specialization) : base()
        {
            BirthDate = birthDate;

            AddServiceman(roleNameServiceman, specialization);
        }

        public Employee(IAssociation roleNameStorekeeper, DateTime birthDate, bool forkliftLicense) : base()
        {
            BirthDate = birthDate;

            AddStorekeeper(roleNameStorekeeper, forkliftLicense);
        }
        public Employee(IAssociation roleNameStorekeeper, IAssociation roleNameServiceman, DateTime birthDate, bool forkliftLicense, string specialization) : base()
        {
            BirthDate = birthDate;

            AddStorekeeper(roleNameStorekeeper, forkliftLicense);

            AddServiceman(roleNameServiceman, specialization);
        }

        private void AddServiceman(IAssociation roleName, string specialization)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            AddPart(roleName, new EmployeeServiceman(BirthDate, specialization));
        }

        private void AddStorekeeper(IAssociation roleName, bool forkliftLicense)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            AddPart(roleName, new EmployeeStorekeeper(BirthDate, forkliftLicense));
        }

        public bool HasForkliftLicense(IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            try
            {
                ObjectPlusPlus[] obj = GetLinks(roleName);
                if (obj.Length != 1 || obj[0] is EmployeeStorekeeper == false)
                {
                    throw new Exception("Obiekt nie jest Magazynierem.");
                }

                return (obj[0] as EmployeeStorekeeper).ForkliftLicense;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Obiekt nie jest Magazynierem.");
            }
        }
        public string HasSpecialization(IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            try
            {
                ObjectPlusPlus[] obj = GetLinks(roleName);
                if (obj.Length != 1 || obj[0] is EmployeeServiceman == false)
                {
                    throw new Exception("Obiekt nie jest Serwisantem.");
                }

                return (obj[0] as EmployeeServiceman).Specialization;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Obiekt nie jest Serwisantem.");
            }
        }
    }
}
