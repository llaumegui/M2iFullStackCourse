using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShawarmAPI.Models;

[Table("shawarmas")]
public class Shawarma
{
    [Key]
    [Column("name")]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("price")]
    [Required]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Column("status")]
    public List<ShawarmaStatus> Status { get; set; } = new() { ShawarmaStatus.None };
    
    [Column("toppings")]
    public List<Topping> Toppings { get; set; }
}

public enum ShawarmaStatus
{
    None,
    Vegetarian,
    Spicy,
    Vegan,
}