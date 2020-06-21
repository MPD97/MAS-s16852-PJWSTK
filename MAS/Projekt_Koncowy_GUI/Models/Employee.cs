using System;

namespace Projekt_Koncowy_GUI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public DateTime BirthDate { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public EmployeeStorekeeper EmployeeStorekeeper { get; set; }
        public EmployeeServiceman EmployeeServicemen { get; set; }
    }
}
