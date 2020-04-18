using System;
using System.Collections.Generic;
using System.Text;

namespace MP01
{
    public class Component : ObjectPlus
    {
        public int Identifier { get; set; }

        public Component(int identifier) : base()
        {
            Identifier = identifier;
        }

        public bool Test()
        {
            throw new NotImplementedException();
        }
    }
} 
