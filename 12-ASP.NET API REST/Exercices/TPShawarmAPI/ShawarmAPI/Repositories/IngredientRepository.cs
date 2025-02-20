using System.Linq.Expressions;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class IngredientRepository : IRepository<Ingredient,Guid>
{
    public Task<Ingredient> Add(Ingredient entity)
    {
        throw new NotImplementedException();
    }
    public Task<Ingredient?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<Ingredient>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<Ingredient>> GetAll(Expression<Func<Ingredient, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<Ingredient?> Update(Ingredient entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}