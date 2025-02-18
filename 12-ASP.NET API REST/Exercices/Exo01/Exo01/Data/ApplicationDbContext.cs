using Exo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext (options)
{
    public DbSet<Contact> Contacts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Contact>().HasData(new Contact()
        {
            Id = -1,
            FirstName = "John",
            LastName = "Doe",
            Birthday = new DateTime(2000, 1, 1),
            Gender = "N"
        });
    }
}