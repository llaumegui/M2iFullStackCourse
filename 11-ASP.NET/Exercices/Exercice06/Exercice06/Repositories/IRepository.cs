using System.Linq.Expressions;
namespace Exercice06.Repositories;

public interface IRepository<T> where T : class
{
    public bool Create(T entity);
    public IEnumerable<T> Read();
    public IEnumerable<T> Read(Expression<Func<T, bool>> predicate);
    public T Read(int id);
    public void Save();
    public bool Delete(T entity);
}

// ASYNC
/*public interface IRepository<T> where T : class
{
    public Task<bool> Create(T entity);
    public Task<IEnumerable<T>> Read();
    public Task<T> Read(int id);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(T entity);
}*/

// EVENTS
/*public interface IRepository<T> where T : class
{
    // conteneurs de fonctionnalités
    public event Action<T> EntityCreated;
    public event Action<T> EntityUpdated;
    
    public Task<bool> Create(T entity);
    public Task<IEnumerable<T>> Read();
    public Task<T> Read(int id);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(T entity);
}*/

