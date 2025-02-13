using System.Linq.Expressions;
using Exercice06.Data;
using Exercice06.Models;

namespace Exercice06.Repositories;

public class MovieRepository(ApplicationDbContext db) : IRepository<Movie>
{
    public bool Create(Movie entity)
    {
        db.Add(entity);
        return db.SaveChanges() > 0;
    }
    public IEnumerable<Movie> Read()
    {
        return db.Movies;
    }

    public IEnumerable<Movie> Read(Expression<Func<Movie, bool>> predicate)
    {
        return db.Movies.Where(predicate);
    }

    public Movie Read(int id)
    {
        return db.Movies.FirstOrDefault(m => m.Id == id);
    }

    public void Save()
    {
        db.SaveChanges();
    }

    public bool Delete(Movie entity)
    {
        db.Remove(entity);
        return db.SaveChanges() > 0;
    }
}