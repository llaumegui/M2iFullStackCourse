using System.ComponentModel.DataAnnotations.Schema;

namespace ShawarmAPI.Models;

[Table("ingredients")]
public class Ingredient
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}