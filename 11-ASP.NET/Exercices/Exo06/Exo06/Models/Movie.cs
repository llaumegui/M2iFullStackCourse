using System.ComponentModel.DataAnnotations;

namespace Exo06.Models;

public class Movie
{
    [Key] public int Id { get; set; }
    [Required] public string Title { get; set; }
    public int? Year { get; set; }
    public string? Director { get; set; }
    public MovieGenre Genre { get; set; } = MovieGenre.Undefined;
    public string? Synopsis { get; set; }
    public Picture Picture { get; set; }

    public bool Seen { get; set; }
    public bool Favorite { get; set; }
}

public enum MovieGenre
{
    Undefined = 0,
    Action,
    Adventure,
    Comedy,
    Drama,
    Horror
}