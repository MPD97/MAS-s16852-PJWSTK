using System;
using System.IO;

namespace MP03
{
    public class UserAdministrator : User
    {
        public UserAdministrator() : base()
        {

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
    }
} 
