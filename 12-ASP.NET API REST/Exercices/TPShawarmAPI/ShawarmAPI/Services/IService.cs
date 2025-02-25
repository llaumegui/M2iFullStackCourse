using System.Linq.Expressions;

namespace ShawarmAPI.Services;

public interface IService<T,Tid> where T : new()
{
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
    Task<T?> GetByKey(Tid id);
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    Task<bool> Add(T element);
    Task<bool> Update(T element);
    Task<bool> Delete(Tid id);
    Task<bool> Save();
}