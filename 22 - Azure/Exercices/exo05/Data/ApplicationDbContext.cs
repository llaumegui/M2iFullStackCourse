using exo05.Models;
using Microsoft.EntityFrameworkCore;

namespace exo05.Data;

public class ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Contact>().HasData(new Contact()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Birthday = new DateTime(2000, 1, 1),
            Gender = 'N'
        });
    }
}