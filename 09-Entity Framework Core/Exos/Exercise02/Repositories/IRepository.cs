namespace Exercise02.Repositories;

public interface IRepository<T,Tid> where T:new()
{
    bool Add(T obj); 
    T? GetById(Tid id);
    T? Get(Func<T, bool> predicate); 
    IEnumerable<T> GetAll(); 
    IEnumerable<T> GetAll(Func<T, bool> predicate);
    bool Delete(Tid id);
    bool Save();
}