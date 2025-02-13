using Exercice06.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice06.Data;

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
                Year = 2008,
                Director = "Christopher Nolan",
                Genre = MovieGenre.Action,
                Synopsis =
                    "Dans la ville de Gotham City, une bande de cambrioleurs déguisés en clowns dévalisent une banque servant à la mafia pour blanchir son argent sale. Chacun des cambrioleurs doit se débarrasser d'un de ses complices, jusqu’à ce qu’il n’en reste plus qu’un : le commanditaire du casse, un psychopathe fou et particulièrement dangereux : le Joker."
            });

        modelBuilder.Entity<Movie>().Property(x => x.Genre).HasConversion<string>();
    }
}