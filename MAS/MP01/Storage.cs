using System;

namespace MP01
{
    public class Storage : ObjectPlus
    {
        public Storage() :base()
        {

        }
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

        public Storage(ulong RAMSize, ulong diskSize, ulong takenRamSpace, ulong takenDiskSpace)
        {
            this.RAMSize = RAMSize;
            DiskSize = diskSize;
            TakenRamSpace = takenRamSpace;
            TakenDiskSpace = takenDiskSpace;
        }
    }
}