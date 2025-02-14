using System.ComponentModel.DataAnnotations;

namespace MoviesCore.Models;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "No Title"),
     MinLength(3, ErrorMessage = "Movie title must be at least 3 characters long"),
     MaxLength(100, ErrorMessage = "Movie title must be at most 100 characters long")]
    public string Title { get; set; }

    public int Genres { get; set; }

    [Required(ErrorMessage = "No Year"),
     Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
    public int Year { get; set; }

    [Required(ErrorMessage = "No Director"),
     MaxLength(100, ErrorMessage = "Director name must be at most 100 characters long")]
    public string Director { get; set; }

    public string? Actors { get; set; }
    public string? PosterURL { get; set; }
    public string? Description { get; set; }
    public bool Seen { get; set; }
}