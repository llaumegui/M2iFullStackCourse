using System.ComponentModel.DataAnnotations.Schema;

namespace ShawarmAPI.Models;

[Table("shawarmas")]
public class Shawarma
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}