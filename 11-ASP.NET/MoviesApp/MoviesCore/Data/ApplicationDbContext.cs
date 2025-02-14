using Microsoft.EntityFrameworkCore;

namespace MoviesCore.Data;

public class ApplicationDbContext : DbContext
{
    internal DbSet<Models.Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\dino; Integrated Security=True;");
    }
}