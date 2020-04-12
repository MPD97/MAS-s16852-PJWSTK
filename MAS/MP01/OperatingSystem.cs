using System;
using System.Collections.Generic;
using System.Text;

namespace MP01
{
    public class OperatingSystem : ObjectPlus
    {
        public string Version { get; set; }
        public string Type { get; set; }

        public void Update()                                // Metoda
        {

        }
        public void Update(string version)                  // Przeciążenie metody
        {

        }
    }
}
