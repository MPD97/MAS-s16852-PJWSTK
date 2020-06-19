using System;

namespace Projekt_Koncowy_GUI.Models
{
    public class EmployeeServiceman
    {
        public int EmployeeServicemanId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Specialization { get; set; }

        public int? EmployeeId { get; set; }            //overlapping
        public Employee Employee { get; set; }
    }
}
