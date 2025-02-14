using Microsoft.EntityFrameworkCore;
using MoviesCore.Data;
using MoviesCore.Models;

namespace MoviesCore.Repository;

public sealed class MovieRepository : BaseRepository<int, Movie>
{
    public override IEnumerable<Movie> GetAll()
    {
        return CurrentDbSet;
    }

    public override Movie? GetById(int id)
    {
        return CurrentDbSet.FirstOrDefault(movie => movie.Id == id);
    }

    protected override DbSet<Movie> GetDbSet(ApplicationDbContext context)
    {
        return context.Movies;
    }
}