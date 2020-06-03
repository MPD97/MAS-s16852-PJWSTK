using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MP03
{
    public class PersonClient : Person
    {
        public PersonClient() : base()
        {

        }
        public override void GetPersonInfo(StreamWriter sw)         // Przesłonięcie metody
        {
            sw.WriteLine("Jestem zwyklym klientem firmy.");
        }
    }
}
