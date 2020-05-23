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
            //var sw = new StreamWriter(Console.OpenStandardOutput());
            //sw.AutoFlush = true;
            //Console.SetOut(sw);


            Warehouse warehouse1 = new Warehouse("Orchidei 14A, 96-321 Słubica B", 350);
            Warehouse warehouse2 = new Warehouse("Samorządowa 26, 26-600 Radom", 221);
            Warehouse warehouse3 = new Warehouse("Południowa 4c, 26-613 Jedlnia-Letnisko", 445);
            Warehouse warehouse4 = new Warehouse("Bursztynowa 11, 26-660 Wsola", 775);

            Server server1 = new Server("Core I7", "Intel", new Storage(3000000000, 50000000000, 1700000000, 1300000000));
            Server server2 = new Server("Core I3", "Intel", new Storage(15000000000, 440000000000, 2888741908, 444440000));

            CommunicationModule communicationModule = new CommunicationModule(4800, "ABC123CDFGHJ098", "Ver1", 1234567823456);
            CommunicationModule communicationModule2 = new CommunicationModule(9600, "WWWXXXX24252332", "Ver4", 45645745865888);
            CommunicationModule communicationModule3 = new CommunicationModule(12800, "IIWWDD22222222", "Ver5.7.1", 999987799999);
            //ObjectPlus.ShowExtent<Warehouse>();
            //ObjectPlus.ShowExtent<Server>();


            // Tworze asocjację między dwoma obiektami.
            Association<Warehouse, Server>             .CreateAssociation<Warehouse, Server>                (warehouse1, server1, 0, 0,"a","b");
            Association<CommunicationModule, Warehouse>.CreateAssociation<CommunicationModule, Warehouse>   (communicationModule, warehouse1, 0, 0, "a", "b");

            // Pobieram utworzoną asociację między obiektami. Kolejnosć ma zawsze znaczenie.
            var associationWarehouseServer = Association<Warehouse, Server>.GetAssociation<Warehouse, Server>(warehouse1, server1);
            var associationCommunicationWarehouse = Association<CommunicationModule, Warehouse>.GetAssociation<CommunicationModule, Warehouse>(communicationModule, warehouse1);

            warehouse1.AddLink(associationWarehouseServer, server1);
            //warehouse1.AddLink(association, server2);

            var links = warehouse1.GetLinks(associationWarehouseServer);

            foreach (var link in links)
            {
                Console.WriteLine(link);
            }
            
            Console.WriteLine(associationWarehouseServer.ToString());

            Console.ReadLine();
        }
    }
}
