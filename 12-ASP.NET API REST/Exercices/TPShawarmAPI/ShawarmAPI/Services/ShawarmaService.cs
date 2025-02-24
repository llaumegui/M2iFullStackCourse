using System.Linq.Expressions;
using AutoMapper;
using ShawarmAPI.Models;
using ShawarmAPI.Repositories;

namespace ShawarmAPI.Services;

public class ShawarmaService(ShawarmaRepository sr, IMapper mapper) : IService<Shawarma>
{
    public async Task<IEnumerable<Shawarma>> GetAll(Expression<Func<Shawarma, bool>>? predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Shawarma?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Any(Expression<Func<Shawarma, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<Shawarma?> Get(Expression<Func<Shawarma, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Add(Shawarma element)
    {
        throw new NotImplementedException();
    }
    public async Task<Shawarma> Update(Shawarma element)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}