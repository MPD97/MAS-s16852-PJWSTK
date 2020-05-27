using MP02.Functional;
using System;


namespace MP02
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
