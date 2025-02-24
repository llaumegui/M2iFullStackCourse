using System.Linq.Expressions;

namespace ShawarmAPI.Services;

public interface IService<T> where T : new()
{
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
    Task<T?> GetById(Guid id);
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    Task<bool> Add(T element);
    Task<T> Update(T element);
    Task<bool> Delete(Guid id);
}