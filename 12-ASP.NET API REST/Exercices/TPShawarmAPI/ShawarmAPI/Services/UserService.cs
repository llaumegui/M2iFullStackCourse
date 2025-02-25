using System.Linq.Expressions;
using ShawarmAPI.Models;
using ShawarmAPI.Repositories;

namespace ShawarmAPI.Services;

public class UserService(UserRepository ur) : IService<User,Guid>
{
    public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? predicate) => await ur.GetAll(predicate);

    public async Task<User?> GetByKey(Guid id) => await ur.GetByKey(id);

    public async Task<User?> Get(Expression<Func<User, bool>> predicate) => await ur.Get(predicate);

    public async Task<bool> Add(User element) => await ur.Add(element);

    public async Task<bool> Update(User element)
    {
        try
        {
            if (await ur.Update(element))
                return true;
            throw new KeyNotFoundException($"User {element} not found");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Update error with {element}: {e.Message}");
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<bool> Delete(Guid id)=>await ur.Delete(id);

    public async Task<bool> Save() => await ur.Save();
}