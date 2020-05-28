using System;

namespace MP03
{
    public class EmployeeServiceman : Employee
    {
        public string Specialization { get; set; }
        protected internal EmployeeServiceman(DateTime birthDate, string specjalization) : base(birthDate)
        {
            Specialization = specjalization;
        }
    }
}
