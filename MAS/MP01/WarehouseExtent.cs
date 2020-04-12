using System;
using System.Collections.Generic;

namespace MP01
{
    public class WarehouseExtent                                                // Extensja klasy
    {
        public int RequiredNumberOfEmployees { get; set; } = 5;                 // Atrybut klasowy

        private List<Warehouse> extent = new List<Warehouse>();
        public void AddWareHouse(Warehouse warehouse)
        {
            extent.Add(warehouse);
        }
        public void RemoveWareHouse(Warehouse wareHouse)
        {
            extent.Remove(wareHouse);
        }
        public void ShowExtent()
        {
            Console.WriteLine($"Extent of class: {typeof(Warehouse).Name}");

            foreach (var warehouse in extent)
            {
                Console.WriteLine(warehouse);
            }
        }
    }

} 
