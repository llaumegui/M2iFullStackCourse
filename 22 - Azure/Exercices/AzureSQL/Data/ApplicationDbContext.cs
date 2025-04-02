using AzureSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSQL.Data;

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