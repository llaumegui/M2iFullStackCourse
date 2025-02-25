using System.Linq.Expressions;
using ShawarmAPI.Models;
using ShawarmAPI.Repositories;

namespace ShawarmAPI.Services;

public class ShawarmaService(ShawarmaRepository sr) : IService<Shawarma,string>
{
    public async Task<IEnumerable<Shawarma>> GetAll(Expression<Func<Shawarma, bool>>? predicate = null)
        => await sr.GetAll(predicate);

    public async Task<Shawarma?> GetByKey(string key) => await sr.GetByKey(key);

    public async Task<Shawarma?> Get(Expression<Func<Shawarma, bool>> predicate) => await sr.Get(predicate);

    public async Task<bool> Add(Shawarma element) => await sr.Add(element);

    public async Task<bool> Update(Shawarma element)
    {
        try
        {
            if (await sr.Update(element))
                return true;
            throw new KeyNotFoundException($"Shawarma {element} not found");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Update error with {element}: {e.Message}");
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<bool> Delete(string key)=>await sr.Delete(key);

    public async Task<bool> Save() => await sr.Save();
}