using eSkyAirways.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace eSkyAirways.Database;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
}