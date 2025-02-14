namespace MoviesCore.Interfaces;

public interface IRepository<TKey, T> : IDisposable, IAsyncDisposable where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(TKey id);
    
    void Add(T item);
    
    void Save();
}