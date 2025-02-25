using System.Linq.Expressions;
using ShawarmAPI.Models;
using ShawarmAPI.Repositories;

namespace ShawarmAPI.Services;

public class ToppingService(ToppingRepository tr) : IService<Topping, string>
{
    public async Task<IEnumerable<Topping>> GetAll(Expression<Func<Topping, bool>>? predicate = null)
        => await tr.GetAll(predicate);

    public async Task<Topping?> GetByKey(string key) => await tr.GetByKey(key);

    public async Task<Topping?> Get(Expression<Func<Topping, bool>> predicate) => await tr.Get(predicate);

    public async Task<bool> Add(Topping element) => await tr.Add(element);

    public async Task<bool> Update(Topping element)
    {
        try
        {
            if (await tr.Update(element))
                return true;
            throw new KeyNotFoundException($"Topping {element} not found");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Update error with {element}: {e.Message}");
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Delete(string key) => await tr.Delete(key);

    public async Task<bool> Save() => await tr.Save();
}