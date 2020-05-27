using MP03;
using System;
using System.IO;

namespace MP03_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Inicjalizacja Strumienia Wyjścia Na Konsole
            var sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
            #endregion

            #region Klasa abstrakcyjna / polimorfizm

            // Instancja klasy User nie może zostać utwrzona
            // User user1 = new User();

            // Tworzę Administratora i zwykłego użytkownika
            User admin = new UserAdministrator();
            User normal = new NormalUser();

            // Jest to możliwe, ponieważ administrator i normalny użytkownik implementuje klasę User.
            // Wywołuję metodę GetUserInfo która jest abstrakcyjna, a ciało metody zostało zaimplementowane
            // w sposób inny w obu podklasach

            admin.GetUserInfo(sw);
            normal.GetUserInfo(sw);

            #endregion


            Console.ReadLine();
        }

        private static ConsoleColor currentForeground = ConsoleColor.White;
        private static void WriteColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentForeground;
        }
    }
}
