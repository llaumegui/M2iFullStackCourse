using Exercise02.Models;
using Microsoft.EntityFrameworkCore;
namespace Exercise02.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base() { }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Hotel> Hotels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\EFCoreDb; Integrated Security = True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder
            .Entity<Room>()
            .Property(r => r.Status)
            .HasConversion(
                v => v.ToString(),
                v => (RoomStatus)Enum.Parse(typeof(RoomStatus), v));
        
        builder.Entity<Booking>()
            .Property(r => r.Status)
            .HasConversion(
            v=>v.ToString(),
            v => (BookingStatus)Enum.Parse(typeof(BookingStatus), v));
            
    }
}