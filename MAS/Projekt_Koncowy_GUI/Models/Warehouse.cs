using System;
using System.Collections.Generic;

namespace Projekt_Koncowy_GUI.Models
{
    public class Warehouse 
    {
        public int WarehouseId { get; set; }
        public string Address { get; set; }
        public int AreaInSquareMeters { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public void CarryOutModernization()
        {
            throw new NotImplementedException();
        }
        public string PrintOutOfStoredDevices()
        {
            throw new NotImplementedException();
        }
        public static void SalesAnalisys()                                    // Metoda klasowa
        {
            throw new NotImplementedException();
        }
    }
}
