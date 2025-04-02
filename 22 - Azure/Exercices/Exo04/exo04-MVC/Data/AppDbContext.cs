using exo04_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace exo04_MVC.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasData(new User { Id = Guid.NewGuid(),FirstName = "Jane", LastName = "Doe" });
    }
}