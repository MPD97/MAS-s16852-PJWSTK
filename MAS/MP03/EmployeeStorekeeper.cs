using System;

namespace MP03
{
    public class EmployeeStorekeeper : Employee
    {
        public bool ForkliftLicense { get; set; }
        protected internal EmployeeStorekeeper(DateTime birthDate, bool forkliftLicense) : base(birthDate)
        {
            ForkliftLicense = forkliftLicense;
        }
    }
} 
