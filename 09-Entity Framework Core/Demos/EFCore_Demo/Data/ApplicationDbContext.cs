using EFCore_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Demo.Data;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base() { }

    public DbSet<Livre> Livres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = (localdb)\\EFCoreDb; Integrated Security = True");
    }
}