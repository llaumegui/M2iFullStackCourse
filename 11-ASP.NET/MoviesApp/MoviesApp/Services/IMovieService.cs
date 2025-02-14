using MoviesCore.Models;

namespace MoviesApp.Services;

public interface IMovieService : IDisposable
{
    Movie[] GetAllMovies();
    Movie? GetMovieById(int id);
    
    void AddMovie(Movie movie);
}