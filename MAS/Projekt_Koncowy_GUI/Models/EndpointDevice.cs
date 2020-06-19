using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class EndpointDevice
    {

        public int Identifier { get; set; }

        public DateTime DateOfProduction { get; set; }

        public string Model { get; set; }


        public Tested Tested { get; set; }
        public TestResult TestResult { get; set; }
        public Gauge Gauge { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }


        public string CommunicationModuleImei { get; set; }
        public CommunicationModule CommunicationModule { get; set; }


        public void PerformAction(Action action)
        {
            throw new NotImplementedException();
        }

        public string GetLocalation()
        {
            throw new NotImplementedException();
        }

        public bool TestDevice()
        {
            throw new NotImplementedException();
        }

        public void ReportRepair(string details)
        {
            throw new NotImplementedException();
        }

        public void ReplaceComponents()
        {
            throw new NotImplementedException();
        }

        public void InstallNewSystem()
        {
            throw new NotImplementedException();

        }

    }
    public enum TestResult
    {
        Negatywny = 0,
        Pozytywny = 1
    }
    public enum Tested
    {
        Nie = 0,
        Tak = 1
    }
    public enum Gauge
    {
        X1,
        X2,
        P
    }
}
