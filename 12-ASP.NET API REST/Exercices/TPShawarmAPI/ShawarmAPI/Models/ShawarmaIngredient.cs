using System.ComponentModel.DataAnnotations.Schema;

namespace ShawarmAPI.Models;

[Table("shawarmas_ingredients")]
public class ShawarmaIngredient
{
    public int ShawarmaId { get; set; }
    public int IngredientId { get; set; }
}