using MP03.Functional;
using System;

namespace MP03
{
    public class EndpointDevice : ObjectPlusPlus
    {
        public int Identifier { get; set; }

        public DateTime DateOfProduction { get; set; }

        public string Model { get; set; }

        public Gauge Gauge { get; set; }

        public EndpointDevice(int identifier, DateTime dateOfProduction, string model, Gauge gauge) : base()
        {
            Identifier = identifier;
            DateOfProduction = dateOfProduction;
            Model = model;
            Gauge = gauge;
        }

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
