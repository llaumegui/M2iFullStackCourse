using System.Linq.Expressions;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class IngredientRepository : IRepository<Ingredient,Guid>
{
    public async Task<bool> Add(Ingredient entity)
    {
        throw new NotImplementedException();
    }
    public async Task<Ingredient?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public async Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Ingredient>> GetAll(Expression<Func<Ingredient, bool>>? predicate)
    {
        throw new NotImplementedException();
    }
    public async Task<Ingredient?> Update(Ingredient entity)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}