using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShawarmAPI.Models;

[Table("toppings")]
public class Topping
{
    [Key]
    [Column("name")]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }

    public List<Shawarma> Shawarmas { get; set; } = new();
}