using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class ComponentAvailableModel
    {
        public int DeviceId { get; set; }

        public string ComponentIdentificator { get; set; }

        public int Amount { get; set; }

        public bool HasReplacement { get; set; }

    }
}
