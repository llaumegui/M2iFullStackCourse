using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Models;

namespace ShawarmAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Shawarma> Shawarmas { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shawarma>()
            .HasMany(e => e.Toppings)
            .WithMany(e => e.Shawarmas)
            .UsingEntity("shawarmas_toppings");
    }
}