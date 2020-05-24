using MP02;
using MP02.Functional;
using System;
using System.IO;

namespace MP02_ConsoleApp
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

            #region Inicjalizacja Obiektów
            Warehouse warehouse1 = new Warehouse("Orchidei 14A, 96-321 Słubica B", 350);
            Warehouse warehouse2 = new Warehouse("Samorządowa 26, 26-600 Radom", 221);
            Warehouse warehouse3 = new Warehouse("Południowa 4c, 26-613 Jedlnia-Letnisko", 445);
            Warehouse warehouse4 = new Warehouse("Bursztynowa 11, 26-660 Wsola", 775);

            Server server1 = new Server("Core I7", "Intel", new Storage(3000000000, 50000000000, 1700000000, 1300000000));
            Server server2 = new Server("Core I3", "Intel", new Storage(15000000000, 440000000000, 2888741908, 444440000));

            EndpointDevice endpointDevice1 = new EndpointDevice(1, DateTime.Now.AddDays(-50), "M365", Gauge.X1);
            EndpointDevice endpointDevice2 = new EndpointDevice(2, DateTime.Now.AddDays(-550), "M365 PRO", Gauge.X2);
            EndpointDevice endpointDevice3 = new EndpointDevice(3, DateTime.Now.AddDays(-80), "City Bike", Gauge.X1);

            CommunicationModule communicationModule1 = new CommunicationModule(4800, "ABC123CDFGHJ098", "Ver1", 1234567823456);
            CommunicationModule communicationModule2 = new CommunicationModule(9600, "WWWXXXX24252332", "Ver4", 45645745865888);
            CommunicationModule communicationModule3 = new CommunicationModule(12800, "IIWWDD22222222", "Ver5.7.1", 999987799999);

            StorageProcess storageProcess1 = new StorageProcess(DateTime.Now, false);
            StorageProcess storageProcess2 = new StorageProcess(DateTime.Now.AddMinutes(-34324), true);
            #endregion


            #region Asocjacja "Zwykła"
            WriteColor($"\r\n|||||||||||||||||||||| ~Asocjacja Zwykla~ |||||||||||||||||||||||", ConsoleColor.DarkGreen);

            // Tworze asocjację "Zwykłą" między dwoma obiektami Warehouse i EndpointDevice o liczności 0..1 Warehouse do wielu EndpointDevice.
            Association<Warehouse, EndpointDevice>.CreateAssociation(1, 0, "przechowuje", "jest przechowywany w");

            // Pobieram utworzoną asociację między obiektami i przypisuję ją do zmiennej.
            var WHEDAssociation = Association<Warehouse, EndpointDevice>.GetAssociation();

            // Wiele EndpointDevice może tworzyć relację z tym samym Magazynem.
            warehouse1.AddLink(WHEDAssociation, endpointDevice1);
            warehouse1.AddLink(WHEDAssociation, endpointDevice3);

            WriteColor($"===================== Stworzone asocjacje =======================", ConsoleColor.Blue);
            warehouse1.ShowLinks(WHEDAssociation, sw);
            WriteColor($"===================== ^^^^^^^^^^^^^^^^^^^ =======================", ConsoleColor.Blue);

            // ... lecz nie możemy dodać relacji z tym samym EndpointDevice dwókrotnie.
            try { warehouse1.AddLink(WHEDAssociation, endpointDevice1); }
            catch (Exception ex)
            { WriteColor($"BLAD: {ex.Message}", ConsoleColor.DarkRed); }


            // Chyba że usuniemy najpierw stworzoną asocjację
            warehouse1.RemoveLink(WHEDAssociation, endpointDevice1);

            WriteColor($"=================== Po usunieciu asocjacji =========+============", ConsoleColor.Blue);
            warehouse1.ShowLinks(WHEDAssociation, sw);
            WriteColor($"=================== ^^^^^^^^^^^^^^^^^^^^^^ ======================", ConsoleColor.Blue);

            // I dodamy ją ponownie.
            warehouse1.AddLink(WHEDAssociation, endpointDevice1);

            // Można także usunąć asocjację w drugą stronę.
            warehouse1.RemoveObject();
            WriteColor($"============== Po usunieciu asocjacji w druga strone ============", ConsoleColor.Blue);
            warehouse1.ShowLinks(WHEDAssociation, sw);
            WriteColor($"============== ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ ============", ConsoleColor.Blue);

            #endregion

            #region Asocjacja Z Atrybutem
            WriteColor($"\r\n|||||||||||||||||||| ~Asocjacja z Atrybutem~ ||||||||||||||||||||", ConsoleColor.DarkGreen);

            // Tworze asocjację z atrybutem z użyciem klasy pośredniczącej StorageProcess, między dwoma obiektami Warehouse i EndpointDevice.
            // StorageProcess wiele, Warehouse      1
            // StorageProcess wiele, EndpointDevice 1
            Association<StorageProcess, Warehouse>.CreateAssociation(0, 1);
            Association<StorageProcess, EndpointDevice>.CreateAssociation(0, 1);

            // Pobieram utworzone asociacje między obiektami i przypisuję ją do zmiennej.
            var SPWAssociation = Association<StorageProcess, Warehouse>.GetAssociation();
            var SPEAssociation = Association<StorageProcess, EndpointDevice>.GetAssociation();

            storageProcess1.AddLink(SPWAssociation, warehouse1);
            storageProcess1.AddLink(SPEAssociation, endpointDevice1);


            // Program nadal pilnuje liczności asocjacji z atrybutem
            try
            {
                storageProcess1.AddLink(SPWAssociation, warehouse2);
                storageProcess1.AddLink(SPEAssociation, endpointDevice2);
            }
            catch (Exception ex)
            {
                WriteColor($"BLAD: {ex.Message}", ConsoleColor.DarkRed); 
            }

            storageProcess1.GetLinks(SPWAssociation);

            #endregion

            #region Asocjacja Kwalifikowana
            WriteColor($"\r\n|||||||||||||||||||| ~Asocjacja Kwalifikowana~ ||||||||||||||||||", ConsoleColor.DarkGreen);

            // Tworzę asocjacje kwalifikowaną między dwoma obiektami EndpointDevice i CommunicationModule, gdzie 
            // CommunicationModule konkretnie identyfikowana unikatowym numerem IMEI.
            // Zaczynam od zdefiniowania zwykłej asocjacji jeden do wielu, gdzie jeden po stronie EndpointDevice, a wiele po stronie CommunicationModule.
            Association<EndpointDevice, CommunicationModule>.CreateAssociation(1, 0);

            // Pobieram utworzoną asociacje między obiektami i przypisuję ją do zmiennej.
            var EDCAssociation = Association<EndpointDevice, CommunicationModule>.GetAssociation();

            // Dodaje powiązania z użyciem kwalifikatora.
            endpointDevice3.AddLink(EDCAssociation, communicationModule1, communicationModule1.IMEI);
            endpointDevice3.AddLink(EDCAssociation, communicationModule2, communicationModule2.IMEI);
            endpointDevice3.AddLink(EDCAssociation, communicationModule3, communicationModule3.IMEI);

            // Pobieram CommunicationModule za pomocą kwalifikatora - IMEI
            var commModule = endpointDevice3.GetLinkedObject(EDCAssociation, communicationModule3.IMEI);

            WriteColor($"========= Obiekt pobrany za pomoca kwalifikatora ================", ConsoleColor.Blue);
            WriteColor($"Czy to ten sam obiekt? {communicationModule3.Equals(commModule)}", ConsoleColor.DarkMagenta);
            Console.WriteLine(commModule.ToStringJSON());
            WriteColor($"========= ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ ================", ConsoleColor.Blue);

            #endregion

            #region Kompozycja
            WriteColor($"\r\n||||||||||||||||||||||||| ~Kompozycja~ ||||||||||||||||||||||||||", ConsoleColor.DarkGreen);

            // Klasa ServerCluster jest częścią całości, czyli klasy Server.

            // 2. Zakazanie współdzielenia części.
            // Realizacja poprzez zwykłe ograniczenie liczności część całość podczas tworzenia asocjacji.
            Association<Server, ServerCluster>.CreateAssociation(1, 0);

            // Pobieram utworzoną asociacje między obiektami i przypisuję ją do zmiennej.
            var SSCssociation = Association<Server, ServerCluster>.GetAssociation();

            // 1. Blokowanie samodzielnego tworzenia części (istnienie części bez całości).
            // Obiekt ServerCluster nie może zostać utworzony "od tak" z uwagi na użycie modyfikatora dostępu Internal.
            // Klasę ServerCluster można utworzyć jedynie podczas istnienia obiektu Server, poprzez użycie metody CreateAndAddPart.
            // Dostęp został ograniczony do poziomu protected internal, więć nie można użyć konstruktora tej klasy poza biblioteką źródłową
            // ServerCluster server = new ServerCluster("aa"); // Błąd kompilacji.

            // Utworzenie i dodanie części do Obiektu-Całości oraz zwrócenie nowo utwrzonego obiektu.
            var serverCluster1 = server1.CreateAndAddPart(SSCssociation, "da:9b:14:b1:aa:70");
            var serverCluster2 = server1.CreateAndAddPart(SSCssociation, "42:a5:eb:d2:8e:88");

            // Wyświetlenie elementów kompozycji przed usunięciem całości.
            WriteColor($"================= Wszystkie elementy kompozycji =================", ConsoleColor.Blue);
            server1.ShowLinks(SSCssociation, sw);
            WriteColor($"================= ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ =================", ConsoleColor.Blue);

            // 3. Usuwanie części przy usuwaniu całości
            server1.RemoveObject();

            // Wyświetlenie elementów kompozycji po usunięciu całości.
            WriteColor($"=== Wszystkie elementy kompozycji po usunieciu czesci-calosci ===", ConsoleColor.Blue);
            server1.ShowLinks(SSCssociation, sw);
            WriteColor($"=== ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ ===", ConsoleColor.Blue);
            #endregion


            WriteColor($"============================ Koniec =============================", ConsoleColor.Blue);
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
