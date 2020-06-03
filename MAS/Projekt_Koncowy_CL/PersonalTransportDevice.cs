using MP03.Functional;

namespace MP03
{
    public class PersonalTransportDevice : ObjectPlusPlus
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
