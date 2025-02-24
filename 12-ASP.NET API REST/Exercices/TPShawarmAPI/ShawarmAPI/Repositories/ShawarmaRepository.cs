using System.Linq.Expressions;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class ShawarmaRepository : IRepository<Shawarma,Guid> {
    
    public async Task<bool> Add(Shawarma entity)
    {
        throw new NotImplementedException();
    }
    public async Task<Shawarma?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public async Task<Shawarma?> Get(Expression<Func<Shawarma, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Shawarma>> GetAll(Expression<Func<Shawarma, bool>>? predicate)
    {
        throw new NotImplementedException();
    }
    public async Task<Shawarma?> Update(Shawarma entity)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}