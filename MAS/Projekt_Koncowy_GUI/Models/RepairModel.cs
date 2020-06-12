using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class RepairModel
    {
        public int DeviceId { get; set; }
        public ComponentModel[] ComponentModels { get; set; }
    }
    public class ComponentModel
    {
        public string ComponentIdentificator { get; set; }

        public int Amount { get; set; }
    }

}
