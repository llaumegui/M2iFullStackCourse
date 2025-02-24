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

    public async Task<User?> GetById(Guid id)=>await dbContext.Users.FirstOrDefaultAsync(u=>u.Id == id);
    public async Task<User?> Get(Expression<Func<User, bool>> predicate)=> await dbContext.Users.FirstOrDefaultAsync(predicate);
    public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? predicate)
    {
        if (predicate != null) return await dbContext.Users.Where(predicate).ToListAsync();
        return await dbContext.Users.ToListAsync();
    }

    public async Task<User?> Update(User entity)
    {
        var user = await GetById(entity.Id);
        if (user != null)
            return dbContext.Users.Update(entity).Entity;
        return null;
    }
    public async Task<bool> Delete(Guid id)
    {
        var user = await GetById(id);
        if (user is null)
            return false;
        
        dbContext.Users.Remove(user);
        return await dbContext.SaveChangesAsync()!=0;
    }
}