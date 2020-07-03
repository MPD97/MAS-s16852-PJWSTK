using MP03.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZPR_7
{
    public class Opinia : ObjectPlusPlus
    {
        public string Komentarz { get; set; }
        public List<string> Plusy { get; set; }
        public List<string> Minusy { get; set; }
        public Ocena Ocena { get; set; }

        public Opinia() : base()
        {

        }
    }
}
