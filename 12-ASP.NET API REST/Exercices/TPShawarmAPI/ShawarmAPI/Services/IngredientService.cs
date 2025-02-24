using System.Linq.Expressions;
using AutoMapper;
using ShawarmAPI.Models;
using ShawarmAPI.Repositories;

namespace ShawarmAPI.Services;

public class IngredientService(IngredientRepository ir, IMapper mapper) : IService<Ingredient>
{
    public async Task<IEnumerable<Ingredient>> GetAll(Expression<Func<Ingredient, bool>>? predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Ingredient?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Any(Expression<Func<Ingredient, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> Add(Ingredient element)
    {
        throw new NotImplementedException();
    }
    public async Task<Ingredient> Update(Ingredient element)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}