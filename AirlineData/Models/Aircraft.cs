using System.Collections.Generic;

namespace AirlineData.Models
{
    public class Aircraft
    {
        public string Registration { get; set; }
        public string Base { get; set; }
        public string IcaoType { get; set; }
        public int PassengerCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public int FuelCapacity { get; set; }
        public int MaxZeroFuelMass { get; set; }
        public int MaxRampMass { get; set; }
        public int MaxTakeoffMass { get; set; }
        public int MaxLandingMass { get; set; }
        public int DryOpertatingMass { get; set; }
        public float DryOpertatingCg { get; set; }
        public float FuelPerformanceFactor { get; set; }
        public List<float> FuelOnBoard { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
        public double Pitch { get; set; }
        public double Yaw { get; set; }
        public double Roll { get; set; }
        public double Tas { get; set; }
        public double Ias { get; set; }
        public double GroundSpeed { get; set; }
    }
}
