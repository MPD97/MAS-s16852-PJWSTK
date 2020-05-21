namespace MP02
{
    public class BluetoothModule : AddOnModule
    {
        public string TransmisionVersion { get; set; }

        public BluetoothModule(string transmisionVersion) : base()
        {
            TransmisionVersion = transmisionVersion;
        }
    }
} 
