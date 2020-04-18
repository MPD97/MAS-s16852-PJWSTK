using System;
using System.Collections.Generic;
using System.Text;

namespace MP01
{
    public class PersonalTransportDevice : ObjectPlus
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        public PersonalTransportDevice(string model, string manufacturer) : base()
        {
            Model = model;
            Manufacturer = manufacturer;
        }
    }
}
