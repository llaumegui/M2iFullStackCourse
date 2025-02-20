using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Models;

namespace ShawarmAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    /*public DbSet<Shawarma> Shawarmas { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ShawarmaIngredient> ShawarmaIngredients { get; set; }*/
    public DbSet<User> Users { get; set; }
    
    
}