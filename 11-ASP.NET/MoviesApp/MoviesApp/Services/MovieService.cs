using MoviesCore.Interfaces;
using MoviesCore.Models;
using MoviesCore.Repository;

namespace MoviesApp.Services;

public class MovieService : IMovieService
{
    private readonly IRepository<int, Movie> _movieRepo = new MovieRepository();

    public void Dispose()
    {
        _movieRepo.Dispose();
    }

    public Movie[] GetAllMovies()
    {
        return _movieRepo.GetAll().ToArray();
    }

    public Movie? GetMovieById(int id)
    {
        return _movieRepo.GetById(id);
    }

    public void AddMovie(Movie movie)
    {
        _movieRepo.Add(movie);
        _movieRepo.Save();
    }
}