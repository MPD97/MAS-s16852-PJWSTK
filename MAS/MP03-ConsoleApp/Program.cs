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

            // Instancja klasy Person nie może zostać utwrzona
            // Person person = new Person();

            // Tworzę PersonClient i zwykłego PersonVisitor
            Person client = new PersonClient();
            Person visitor = new PersonVisitor();

            // Jest to możliwe, ponieważ PersonClient i PersonVisitor implementuje klasę Person.
            // Wywołuję metodę GetUserInfo która jest abstrakcyjna, a ciało metody zostało zaimplementowane
            // w sposób inny w obu podklasach

            client.GetPersonInfo(sw);
            visitor.GetPersonInfo(sw);

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

            // Blokada tworzenia części (klas między którymi zachodzi overlapping), bez istnienia klasy całości (nadklasy).
            // EmployeeServiceman employeeServiceman = new EmployeeServiceman(DateTime.Now, "ENGINEER");
            // EmployeeStorekeeper employeeStorekeeper = new EmployeeStorekeeper(DateTime.Now, true);

            // Utworzenie klas miedyz ktorymi zachodzi overlapping
            Employee serviceman = new Employee(servicemanAssociation, DateTime.Now.AddYears(30), "ENGINEER");
            Employee storekeeper = new Employee(storekeeperAssociation, DateTime.Now.AddYears(25), true);

            // Pobranie wartości unikatowych dla podklas
            WriteColor($"Jaka ma specjalizacje: {serviceman.HasSpecialization(servicemanAssociation)}", ConsoleColor.Blue);
            WriteColor($"Posiada licencje na wozki widlowe: {storekeeper.HasForkliftLicense(storekeeperAssociation)}", ConsoleColor.Green);

            // A teraz pokazanie że overlapping działa
            Employee servicemanAndStorekeeper = new Employee(storekeeperAssociation, servicemanAssociation, DateTime.Now.AddYears(25), false, "ROBOTICS");

            // Wyświetlenie właściwości między którymi zachodzi overlapping
            WriteColor($"Jaka ma specjalizacje: {servicemanAndStorekeeper.HasSpecialization(servicemanAssociation)}", ConsoleColor.Blue);
            WriteColor($"Posiada licencje na wozki widlowe: {servicemanAndStorekeeper.HasForkliftLicense(storekeeperAssociation)}", ConsoleColor.Green);

            #endregion

            #region Wielodziedziczenie

            // Realizacja wielodziedziczenia z wykorzystaniem kompozycji

            // W tym przykładzie całościa jest klasa AllInOneModule, a częścią GPSModule. Klasa dziedziczy z BluetoothModule.
            Association<AllInOneModule, GPSModule>.CreateAssociation(1, 0);

            // Pobieram utworzone asociacje między obiektami i przypisuje je do zmiennych.
            var AIOMAssociation = Association<AllInOneModule, GPSModule>.GetAssociation();

            // Stworzenie zwykłej instancji klasy GPSModule
            GPSModule gpsModule = new GPSModule(new string[] { "AVLSAT", "EzLink", "Kingneed" });

            // Wyswietlenie wyniku metody GetAmoutOfConnectedDevices()
            // Dla zwykłego modułu GPS Wyświetlone zostaną tylko informacje o satelitach
            WriteColor(gpsModule.GetAmoutOfConnectedDevices(), ConsoleColor.DarkGreen);

            // Utworzenie wielodziedziczenionej klasy z użyciem kompozycji
            AllInOneModule aioModule = new AllInOneModule(AIOMAssociation, "5.0", new string[] { "AVLSAT", "EzLink", "Kingneed" });

            // Wyswietlenie wyniku metody GetAmoutOfConnectedDevices() 
            // Dla wielodziedziczonego modułu GPS oraz Bluetooth wyświetlone zostaną informacje z obu modułów.
            WriteColor(aioModule.GetAmoutOfConnectedDevices(), ConsoleColor.Blue);
            #endregion

            #region Wieloaspektowe

            // Realizacja dziedziczenia wieloaspektowego metodą 1.
            // Atrybuty i metody ze zlikwidowanego aspektu umieszczam w nadklasie
            // Klasa przed zlikwidowaniem widoczna na obrazie "Wieloaspektowe.png"

            License license = new License { Identificator = "ABC123" };

            // Licencja nie może być jednocześnie pudełkowa i cyfrowa.
            try
            {
                license.BoxNumber = "EFG678";
            }
            catch (Exception ex)
            {
                WriteColor($"BLAD: {ex.Message}", ConsoleColor.Red);
            }
            #endregion

            #region Dynamic

            // Implementacja dziedziczenia dynamicznego z użyciem kompozycji i construktora kopiującego

            // Tworzę potrzebne asocjacje między klasami
            // W tym przykładzie całościa jest klasa User, a częsciami, między którymi zachodzi dziedziczenie dynamiczne, NormalUser oraz UserAdministrator.
            Association<User, NormalUser>.CreateAssociation(1, 0);
            Association<User, UserAdministrator>.CreateAssociation(1, 0);

            // Pobieram utworzone asociacje między obiektami i przypisuje je do zmiennych.
            var normalUserAssociation = Association<User, NormalUser>.GetAssociation();
            var administratorUserAssociation = Association<User, UserAdministrator>.GetAssociation();

            // Tworzę Administratora
            User admin = new User(administratorUserAssociation, normalUserAssociation);

            // Wywołuje metodę dostępną tylko dla administratora
            WriteColor(admin.HasIsUserLogged(administratorUserAssociation), ConsoleColor.DarkGreen);

            // Następnie uzytkownik który był adminiem staje się zwykłym użytkownikiem zachowując swoje właściwości.
            admin = new User(normalUserAssociation, administratorUserAssociation);

            // Występuje bład gdyż użytkownik nie posiada metody pokazującej zalogowanych uzytkowników.
            try
            {
                WriteColor(admin.HasIsUserLogged(administratorUserAssociation), ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                WriteColor($"BLAD: {ex.Message}", ConsoleColor.Red);
            }

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
