using System.ComponentModel.DataAnnotations;

namespace Exo04.Models;

public class Marmoset
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "Nom")]
    public string Name { get; set; }
    
    [Display(Name = "Age")]
    public int Age { get; set; }
    
    [Display(Name = "Race")]
    public string? Race { get; set; }
}