using System;
using System.ComponentModel;
using System.Text;

namespace MP01
{
    public class Warehouse : ObjectPlus
    {
        public string Address { get; set; }
        public int AreaInSquareMeters { get; set; }

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
        public void SalesAnalisys()
        {
            throw new NotImplementedException();
        }


    }

} 
