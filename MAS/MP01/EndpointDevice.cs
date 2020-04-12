using System;
using System.Collections.Generic;
using System.Text;

namespace MP01
{
    public class EndpointDevice : ObjectPlus
    {
        public int Identifier { get; set; }

        public DateTime DateOfProduction { get; set; }

        public string Model { get; set; }

        public Gauge Gauge { get; set; }

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
}
