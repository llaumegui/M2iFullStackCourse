using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Data;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IRepository<User, Guid>
{
    public async Task<bool> Add(User entity)
    {
        await dbContext.Users.AddAsync(entity);
        return await dbContext.SaveChangesAsync() != 0;
    }

    public async Task<User?> GetByKey(Guid id) => await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User?> Get(Expression<Func<User, bool>> predicate) =>
        await dbContext.Users.FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? predicate)
    {
        if (predicate != null) return await Task.Run(() => dbContext.Users.Where(predicate));
        return await Task.Run(() => dbContext.Users);
    }

    public async Task<bool> Update(User entity)
    {
        var user = await GetByKey(entity.Id);
        if (user != null)
            return await Save();
        return false;
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = await GetByKey(id);
        if (user is null)
            return false;

        dbContext.Users.Remove(user);
        return await Save();
    }

    public async Task<bool> Save()=>await dbContext.SaveChangesAsync()!=0;
}