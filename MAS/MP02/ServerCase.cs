using MP02.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP02
{
    public class ServerCase : ObjectPlusPlus
    {
        public string Brand { get; set; }
        internal ServerCase(string brand) : base()
        {
            Brand = brand;
        }
    }
}
