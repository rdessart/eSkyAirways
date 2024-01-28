namespace eSkyAirways.Database.Entities;

public class Flight
{
    public Guid FlightId { get; set; }
    
    public string StartIcao { get; set; }
    
    public string EndIcao { get; set; }
    
    public bool IsLive { get; set; }
    
    public List<Guid> CrewsId { get; set; }
    
    public string AircraftRegistration { get; set; }
    
    public DateTime? OffBlockTime { get; set; }
    
    public DateTime? TakeoffTime { get; set; }
    
    public DateTime? LandingTime { get; set; }
    
    public DateTime? OnBlockTime { get; set; }
    
    public double? OffBlockFuel { get; set; }
    
    public double? TakeoffFuel { get; set; }
    
    public double? LandingFuel { get; set; }
    
    public double? OnBlockFuel { get; set; }
}