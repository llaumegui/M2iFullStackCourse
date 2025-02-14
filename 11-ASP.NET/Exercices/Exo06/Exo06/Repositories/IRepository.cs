namespace Exo06.Repositories;

public interface IRepository<T> where T : class
{
    public bool Create(T entity);
    public bool Delete(T entity);
    public void Save();
    public IEnumerable<T> GetAll();
    public IEnumerable<T> Get(Func<T, bool> predicate);
    public T GetById(int id);
}