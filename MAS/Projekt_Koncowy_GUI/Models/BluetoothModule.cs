namespace Projekt_Koncowy_GUI.Models
{
    public class BluetoothModule
    {
        public int BluetoothModuleId { get; set; }
        public string TransmisionVersion { get; set; }


        public int AddOnModuleId { get; set; }
        public AddOnModule AddOnModule { get; set; }

    }
}
