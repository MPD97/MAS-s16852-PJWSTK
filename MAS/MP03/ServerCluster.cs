using MP02.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP02
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
