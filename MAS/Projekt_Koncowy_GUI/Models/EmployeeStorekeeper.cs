using System;

namespace Projekt_Koncowy_GUI.Models
{
    public class EmployeeStorekeeper
    {
        public int EmployeeStorekeeperId { get; set; }
        public DateTime BirthDate { get; set; }
        public bool ForkliftLicense { get; set; }


        public int ?EmployeeId { get; set; }            //overlapping
        public Employee Employee { get; set; }
    }
}
