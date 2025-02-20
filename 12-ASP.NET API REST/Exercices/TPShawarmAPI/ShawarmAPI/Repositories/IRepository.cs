using System.Linq.Expressions;

namespace ShawarmAPI.Repositories;

public interface IRepository<T,TId> where T : new()
{
    Task<T> Add(T entity);
    Task<T?> GetById(TId id);
    Task<T?> Get(Expression<Func<T, bool>> predicate); // Expression permet une meilleure optimisation avec EF Core
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
    Task<T?> Update(T entity);
    Task<bool> Delete(TId id);
}