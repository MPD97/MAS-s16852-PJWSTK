using MP03.Functional;

namespace MP03
{
    public class OperatingSystem : ObjectPlusPlus
    {
        public string Version { get; set; }
        public string Type { get; set; }

        public OperatingSystem(string version, string type) : base()
        {
            Version = version;
            Type = type;
        }

        public void Update()                                // Metoda
        {

        }
        public void Update(string version)                  // Przeciążenie metody
        {

        }
    }
}
