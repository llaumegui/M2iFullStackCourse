using System.ComponentModel.DataAnnotations.Schema;

namespace ShawarmAPI.Models;

[Table("shawarmas_toppings")]
public class ShawarmaTopping
{
    public int ShawarmaId { get; set; }
    public int IngredientId { get; set; }
}