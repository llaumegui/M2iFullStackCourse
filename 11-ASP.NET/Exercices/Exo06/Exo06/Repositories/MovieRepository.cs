using Exo06.Controllers;
using Exo06.Models;

namespace Exo06.Repositories;

public class MovieRepository(ApplicationDbContext db) : IRepository<Movie>
{
    public bool Create(Movie entity)
    {
        db.Movies.Add(entity);
        return db.SaveChanges() > 0;
    }
    public bool Delete(Movie entity)
    {
        db.Movies.Remove(entity);
        return db.SaveChanges() == 1;
    }
    public void Save()=>db.SaveChanges();
    public IEnumerable<Movie> GetAll()=>db.Movies.ToList();
    public IEnumerable<Movie> Get(Func<Movie, bool> predicate)=>db.Movies.Where(predicate);
    public Movie GetById(int id)=>db.Movies.FirstOrDefault(m => m.Id == id);
    
}