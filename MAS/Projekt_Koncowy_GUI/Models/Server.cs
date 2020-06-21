using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class Server
    {
        public int ServerId { get; set; }
        public string ProcessorModel { get; set; }
        public string ProcessorManufacturer { get; set; }

        public Storage Storage { get; set; }                // Klasa do reprezentacji atrubutu złożonego

        public ServerVM ServerVM { get; set; }
        public ICollection<OperatingSystem> OperatingSystems  { get; set; }

    }
    public class Storage
    {
        public int StorageId { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }

        public ulong FreeRamSpace { get { return RAMSize - TakenRamSpace; } }                               // Atrybut pochodny.
        private ulong _takenRAMSpace;
        public ulong TakenRamSpace
        {
            get { return _takenRAMSpace; }
            set
            {
                if (value > RAMSize)
                {
                    throw new ArgumentOutOfRangeException("Value cannot exceed the size of the RAM");
                }
                else
                {
                    _takenRAMSpace = value;
                }
            }
        }
        public ulong RAMSize { get; set; }

        public ulong FreeDiskSpace { get { return DiskSize - TakenDiskSpace; } }                            // Atrybut pochodny.  

        private ulong _takenDiskSpace;
        public ulong TakenDiskSpace
        {
            get { return _takenDiskSpace; }
            set
            {
                if (value > DiskSize)
                {
                    throw new ArgumentOutOfRangeException("Value cannot exceed the size of the disk");
                }
                else
                {
                    _takenDiskSpace = value;
                }
            }
        }
        public ulong DiskSize { get; set; }

        public string MemoryState                                                                           // Atrybut złożony
        {
            get
            {
                return $"Całkowita ilość pamięci RAM: {(((double)RAMSize) / 1000000000).ToString("0.##")}GB\r\n" +
                    $"Zajęta ilość pamięci RAM: {(((double)TakenRamSpace) / 1000000000).ToString("0.##")}GB\r\n" +
                    $"Wolna ilość pamięci RAM: {(((double)FreeRamSpace) / 1000000000).ToString("0.##")}GB\r\n" +
                    $"Całkowita ilość pamięci dyskowej: {(((double)DiskSize) / 1000000000).ToString("0.##")}GB\r\n" +
                    $"Zajęta ilość pamięci dyskowej: {(((double)TakenDiskSpace) / 1000000000).ToString("0.##")}GB\r\n" +
                    $"Wolna ilość pamięci dyskowej: {(((double)FreeDiskSpace) / 1000000000).ToString("0.##")}GB\r\n";
            }
        }

    }

    public class ServerVM
    {
        public int ServerVMId { get; set; }
        public string VirtualMAC { get; set; }


        public int ServerId { get; set; }
        public Server Server { get; set; }
    }
}

