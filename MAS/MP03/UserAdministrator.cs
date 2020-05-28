using System;
using System.IO;

namespace MP03
{
    public class UserAdministrator : User
    {
        protected internal UserAdministrator(NormalUser user) : base()
        {
            // Kopiowanie właściwości
        }

        public static void AddUser()                                                           // Metoda klasowa
        {
            throw new NotImplementedException();
        }
        public static void DeleteUser()
        {
            throw new NotImplementedException();                                               // Metoda klasowa
        }
        public override void GetUserInfo(StreamWriter streamWriter)                            // Przesłonięcie metody
        {
            streamWriter.WriteLine("Jestem Administratorem");
        }
        public string IsUserLogged()                   // Przesłonięcie metody
        {
            return $"Uzytkownik {(new Random().NextDouble() > 0.5 ? "jest" : "nie jest")} zalogowany.";
        }
    }
}
