using MP03.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP03
{
    public class ServerCluster : ObjectPlusPlus
    {
        public string MAC { get; set; }
        protected internal ServerCluster(string mac) : base()
        {
            MAC = mac;
        }
    }
}
