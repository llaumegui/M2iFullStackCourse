using Exercice05.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice05.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base() { }

    public DbSet<Marmoset> Marmosets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ASPdb; Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marmoset>().HasData(
            new Marmoset() { Id = 1, Name = "Bibi", Color = "red", Age = 25 },
            new Marmoset() { Id = 2, Name = "Bobo", Color = "blue", Age = 12 });
    }
}