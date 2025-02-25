using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Data;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class ToppingRepository(ApplicationDbContext dbContext) : IRepository<Topping,string>
{
    public async Task<bool> Add(Topping entity)
    {
        await dbContext.Toppings.AddAsync(entity);
        return await Save();
    }
    
    public async Task<Topping?> GetByKey(string key)=> await dbContext.Toppings.FirstOrDefaultAsync(x => x.Name == key);

    public async Task<Topping?> Get(Expression<Func<Topping, bool>> predicate)
        => await dbContext.Toppings.FirstOrDefaultAsync(predicate);
    
    public async Task<IEnumerable<Topping>> GetAll(Expression<Func<Topping, bool>>? predicate)
    {
        if (predicate != null) return await Task.Run(() => dbContext.Toppings.Where(predicate));
        return await Task.Run(() => dbContext.Toppings);
    }
    
    public async Task<bool> Update(Topping entity)
    {
        var topping = await GetByKey(entity.Name);
        if (topping != null)
            return await Save();
        return false;
    }
    public async Task<bool> Delete(string key)
    {
        var topping = await GetByKey(key);
        if (topping != null)
            await Task.Run(()=> dbContext.Remove(topping));
        return await Save();
    }

    public async Task<bool> Save()=> await dbContext.SaveChangesAsync() != 0;
}