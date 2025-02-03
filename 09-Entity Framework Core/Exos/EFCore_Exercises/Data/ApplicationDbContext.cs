using EFCore_Exercises.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Exercises.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base() { }
    
    public DbSet<Character> Characters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\EFCoreDb; Integrated Security = True");
    }
}