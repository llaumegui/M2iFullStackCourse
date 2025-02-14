using Exo06.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo06.Controllers;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie()
            {
                Id = 1,
                Title = "The Dark Knight",
                Year = 2008
            });

        modelBuilder.Entity<Movie>().Property(x => x.Genre).HasConversion<string>();
    }
}