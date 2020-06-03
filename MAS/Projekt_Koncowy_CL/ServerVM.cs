using MP03.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP03
{
    public class ServerVM : ObjectPlusPlus
    {
        public string VirtualMAC { get; set; }
        protected internal ServerVM(string mac) : base()
        {
            VirtualMAC = mac;
        }
    }
}
