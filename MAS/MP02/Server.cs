using MP02.Functional;
using System;

namespace MP02
{
    public class Server : ObjectPlusPlus
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

        public ServerCase CreateAndAddPart<X,Y>(Association<X, Y> association, string brand) where X: ObjectPlusPlus where Y : ObjectPlusPlus
        {
            try
            {
                return AddPart(association, new ServerCase(brand));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BLAD: {ex.Message}");
                return null;
            }
        }
    
    }
}
