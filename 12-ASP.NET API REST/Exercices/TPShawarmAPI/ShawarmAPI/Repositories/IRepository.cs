using System.Linq.Expressions;

namespace ShawarmAPI.Repositories;

public interface IRepository<T,TId> where T : new()
{
    Task<bool> Add(T entity);
    Task<T?> GetByKey(TId id);
    Task<T?> Get(Expression<Func<T, bool>> predicate); // Expression permet une meilleure optimisation avec EF Core
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
    Task<bool> Update(T entity);
    Task<bool> Delete(TId id);
    Task<bool> Save();
}