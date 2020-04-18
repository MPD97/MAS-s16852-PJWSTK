using System;
using System.Collections.Generic;
using System.Text;

namespace MP01
{
    public class Server : ObjectPlus
    {
        public string ProcessorModel { get; set; }
        public string ProcessorManufacturer { get; set; }
        public Storage Storage { get; set; }                // Klasa do reprezentacji atrubutu złożonego

        public Server(string processorModel, string processorManufacturer, Storage storage) : base()
        {
            ProcessorModel = processorModel;
            ProcessorManufacturer = processorManufacturer;
            Storage = storage;
        }
    }
}
