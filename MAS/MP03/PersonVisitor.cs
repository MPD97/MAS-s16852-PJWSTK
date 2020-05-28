using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MP03
{
    public class PersonVisitor : Person
    {
        public PersonVisitor() : base()
        {

        }

        public override void GetPersonInfo(StreamWriter sw)         // Przesłonięcie metody
        {
            sw.WriteLine("Ja tylko sie rozgladam");
        }
    }
}
