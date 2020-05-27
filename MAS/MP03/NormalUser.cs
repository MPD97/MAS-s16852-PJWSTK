using System.IO;

namespace MP03
{
    public class NormalUser : User
    {
        public NormalUser() :base()
        {

        }

        public override void GetUserInfo(StreamWriter streamWriter)                     // Przesłonięcie metody
        {
            streamWriter.WriteLine("Jestem Uzytkownikiem.");
        }
    }
} 
