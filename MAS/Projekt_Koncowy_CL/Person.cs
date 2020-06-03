using MP03.Functional;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MP03
{
    public abstract class Person : ObjectPlusPlus
    {
        public abstract void GetPersonInfo(StreamWriter sw);
    }
}
