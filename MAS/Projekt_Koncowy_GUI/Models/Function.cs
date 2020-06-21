using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class Function
    {
        public int FunctionId { get; set; }
        public string AvailableFunction { get; set; }

        public int UTOId { get; set; }
        public UTO UTOs { get; set; }

        public int OperatingSystemId { get; set; }
        public OperatingSystem OperatingSystem { get; set; }

    }
    public class UTO
    {
        public int UTOId { get; set; }

        public string Model { get; set; }
        public string Manufacturer { get; set; }

        public ICollection<Function> Functions { get; set; }
    }
}
