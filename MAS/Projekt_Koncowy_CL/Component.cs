using MP03.Functional;
using System;


namespace MP03
{
    public class Component : ObjectPlusPlus
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
