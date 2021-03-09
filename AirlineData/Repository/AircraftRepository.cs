using AirlineData.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirlineData.Repository
{
    public class AircraftRepository
    {
        public List<Aircraft> Fleet { get; set; }

        public AircraftRepository()
        {
            Fleet = new List<Aircraft>()
            {
                new Aircraft()
                {
                    Registration = "OOESA",
                    Base = "EBBR",
                    CargoCapacity = 10_000,
                    PassengerCapacity = 135,
                    MaxLandingMass = 66_000,
                    MaxTakeoffMass = 74_000,
                    MaxZeroFuelMass = 61_000,
                    MaxRampMass = 66_400,
                    DryOpertatingMass = 41_000,
                    DryOpertatingCg = 40.0f,
                    FuelCapacity = 17_400,
                    FuelOnBoard = new List<float>
                    {
                        0.0f, 300.0f, 300.0f,
                        750.0f, 750.0f, 0.0f,
                        0.0f, 0.0f, 0.0f
                    },
                    Elevation = 00.0,
                    FuelPerformanceFactor = 1.300f,
                    GroundSpeed = 0.0,
                    Ias = 0.0,
                    Tas = 0.0,
                    IcaoType = "A320-214",
                    Latitude = 0.0,
                    Longitude = 0.0,
                    Pitch = 0.0,
                    Roll = 0.0,
                    Yaw = 0.0
                },
                new Aircraft()
                {
                    Registration = "OOESB",
                    Base = "EBBR",
                    CargoCapacity = 10_000,
                    PassengerCapacity = 135,
                    MaxLandingMass = 66_000,
                    MaxTakeoffMass = 74_000,
                    MaxZeroFuelMass = 61_000,
                    MaxRampMass = 66_400,
                    DryOpertatingMass = 41_000,
                    DryOpertatingCg = 40.0f,
                    FuelCapacity = 17_400,
                    FuelOnBoard = new List<float>
                    {
                        0.0f, 300.0f, 300.0f,
                        750.0f, 750.0f, 0.0f,
                        0.0f, 0.0f, 0.0f
                    },
                    Elevation = 00.0,
                    FuelPerformanceFactor = 1.300f,
                    GroundSpeed = 0.0,
                    Ias = 0.0,
                    Tas = 0.0,
                    IcaoType = "A320-214",
                    Latitude = 0.0,
                    Longitude = 0.0,
                    Pitch = 0.0,
                    Roll = 0.0,
                    Yaw = 0.0
                }
            };
        }
        public Aircraft GetOneByRegistration(string registration)
        {
            return Fleet.Where(ac => ac.Registration == registration).FirstOrDefault();
        }
        public List<Aircraft> GetAllAtBase(string base_icao)
        {
            return Fleet.Where(ac => ac.Base == base_icao).ToList();
        }
        public List<Aircraft> GetAll()
        {
            return Fleet;
        }
    }
}
