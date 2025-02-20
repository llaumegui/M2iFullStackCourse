using System.Linq.Expressions;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class UserRepository : IRepository<User, Guid>
{
    public Task<User> Add(User entity)
    {
        throw new NotImplementedException();
    }
    public Task<User?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task<User?> Get(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<User?> Update(User entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}