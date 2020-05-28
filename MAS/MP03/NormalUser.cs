using System.IO;

namespace MP03
{
    public class NormalUser : User
    {

        protected internal NormalUser(User user) : base()
        {
            // Kopiowanie właściwości
        }

        public override void GetUserInfo(StreamWriter streamWriter)                     // Przesłonięcie metody
        {
            streamWriter.WriteLine("Jestem Uzytkownikiem.");
        }
    }
} 
