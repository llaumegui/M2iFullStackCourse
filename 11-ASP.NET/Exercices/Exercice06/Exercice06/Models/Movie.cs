using System.ComponentModel.DataAnnotations;

namespace Exercice06.Models;

public class Movie
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    
    [Display(Name = "Année")]
    public int Year { get; set; }
    
    [Display(Name = "Réalisateur")]
    public string Director { get; set; } = string.Empty;
    
    [Display(Name = "Vu")]
    public bool Watched { get; set; }

    public MovieGenre Genre { get; set; } = 0;
    
    public string Synopsis { get; set; } = string.Empty;
}

public enum MovieGenre
{
    Action,
    Adventure,
    Comedy,
    Drama,
    Horror
}