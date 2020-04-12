using MP01;
using System;
using System.IO;

namespace MP01_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathJSONSerialized = Path.Combine(pathDesktop, "MP01", "serialized.json");
            if (File.Exists(pathJSONSerialized) == false)
            {
                Warehouse warehouse1 = new Warehouse("Orchidei 14A, 96-321 Słubica B", 350);
                Warehouse warehouse2 = new Warehouse("Samorządowa 26, 26-600 Radom", 221);
                Warehouse warehouse3 = new Warehouse("Południowa 4c, 26-613 Jedlnia-Letnisko", 445);
                Warehouse warehouse4 = new Warehouse("Bursztynowa 11, 26-660 Wsola", 775);

                Server server1 = new Server("Core I7", "Intel", new Storage(3000000000, 50000000000, 1700000000, 1300000000));
                Server server2 = new Server("Core I3", "Intel", new Storage(15000000000, 440000000000, 2888741908, 444440000));

                ObjectPlus.ShowExtent<Warehouse>();
                ObjectPlus.ShowExtent<Server>();


                FileInfo fileInfo = new FileInfo(pathJSONSerialized);
                if (!fileInfo.Directory.Exists)
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }

                using (StreamWriter sw = new StreamWriter(pathJSONSerialized))
                {
                    ObjectPlus.WriteExtents(sw);
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(pathJSONSerialized))
                {
                    ObjectPlus.ReadExtents(sr);
                }

                ObjectPlus.ShowExtent<Warehouse>();
                ObjectPlus.ShowExtent<Server>();
            }

            Console.ReadLine();
        }
    }
}
