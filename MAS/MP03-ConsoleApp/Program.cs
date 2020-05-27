using MP03;
using MP03.Functional;
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

            #region Overlapping

            // Realizacja overlapping z wykorzystaniem kompozycji

            // Tworzę potrzebne asocjacje między klasami
            // W tym przykładzie całościa jest klasa Employee, a częsciami, między którymi zachodzi overlapping, EmployeeServiceman oraz EmployeeStorekeeper.
            Association<Employee, EmployeeServiceman>.CreateAssociation(1, 0);
            Association<Employee, EmployeeStorekeeper>.CreateAssociation(1, 0);

            // Pobieram utworzone asociacje między obiektami i przypisuje je do zmiennych.
            var servicemanAssociation = Association<Employee, EmployeeServiceman>.GetAssociation();
            var storekeeperAssociation = Association<Employee, EmployeeStorekeeper>.GetAssociation();



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
