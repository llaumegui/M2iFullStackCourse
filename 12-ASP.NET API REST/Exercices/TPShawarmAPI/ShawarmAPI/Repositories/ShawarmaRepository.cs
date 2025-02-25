using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Data;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class ShawarmaRepository(ApplicationDbContext dbContext) : IRepository<Shawarma,string> {
    
    public async Task<bool> Add(Shawarma entity)
    {
        await dbContext.Shawarmas.AddAsync(entity);
        return await Save();
    }
    
    public async Task<Shawarma?> GetByKey(string key)=> await dbContext.Shawarmas.FirstOrDefaultAsync(x => x.Name == key);

    public async Task<Shawarma?> Get(Expression<Func<Shawarma, bool>> predicate)
        => await dbContext.Shawarmas.FirstOrDefaultAsync(predicate);
    
    public async Task<IEnumerable<Shawarma>> GetAll(Expression<Func<Shawarma, bool>>? predicate)
    {
        if (predicate != null) return await Task.Run(() => dbContext.Shawarmas.Where(predicate));
        return await Task.Run(() => dbContext.Shawarmas);
    }
    
    public async Task<bool> Update(Shawarma entity)
    {
        var shawarma = await GetByKey(entity.Name);
        if (shawarma != null)
            return await Save();
        return false;
    }
    public async Task<bool> Delete(string key)
    {
        var shawarma = await GetByKey(key);
        if (shawarma != null)
            await Task.Run(()=> dbContext.Remove(shawarma));
        return await Save();
    }

    public async Task<bool> Save()=> await dbContext.SaveChangesAsync() != 0;
}