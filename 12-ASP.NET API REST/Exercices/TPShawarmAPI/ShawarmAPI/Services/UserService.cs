using System.Linq.Expressions;
using AutoMapper;
using ShawarmAPI.Exceptions;
using ShawarmAPI.Models;
using ShawarmAPI.Repositories;

namespace ShawarmAPI.Services;

public class UserService(UserRepository ur) : IService<User>
{
    public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? predicate) => await ur.GetAll(predicate);

    public async Task<User?> GetById(Guid id) => await ur.GetById(id);

    public async Task<User?> Get(Expression<Func<User, bool>> predicate) => await ur.Get(predicate);

    public async Task<bool> Add(User element) => await ur.Add(element);

    public async Task<User> Update(User element)
    {
        try
        {
            return await ur.Update(element) ?? throw new NotFoundException($"User {element} not found");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Update error with {element}: {e.Message}");
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<bool> Delete(Guid id)=>await ur.Delete(id);
}