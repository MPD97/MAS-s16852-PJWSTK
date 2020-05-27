using MP02.Functional;
using System;


namespace MP02
{
    public class Warehouse : ObjectPlusPlus
    {
        public string Address { get; set; }
        public int AreaInSquareMeters { get; set; }
        public static int RequiredNumberOfEmployees { get; set; } = 5;        // Atrybut klasowy

        public Warehouse(string address, int areaInSquareMeters) : base()
        {
            Address = address;
            AreaInSquareMeters = areaInSquareMeters;
        }
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
