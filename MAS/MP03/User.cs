using MP03.Functional;
using System.IO;

namespace MP03
{
    public abstract class User : ObjectPlusPlus                             // Klasa abstrakcyjna
    {
        public abstract void GetUserInfo(StreamWriter streamWriter);        // Metoda abstrakcyjna
    }
} 
