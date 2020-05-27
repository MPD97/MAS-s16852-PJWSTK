using MP03.Functional;
using System;

namespace MP03
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

        public ServerCluster CreateAndAddPart<X, Y>(Association<X, Y> association, string mac) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            return AddPart(association, new ServerCluster(mac));
        }
        public ServerCluster CreateAndAddPart<X, Y>(Association<X, Y> association, ServerCluster existingCluster) where X : ObjectPlusPlus where Y : ObjectPlusPlus
        {
            if (existingCluster == null)
            {
                throw new Exception("ServerCluster nie może być null.");
            }
            return AddPart(association, existingCluster);
        }

    }
}
