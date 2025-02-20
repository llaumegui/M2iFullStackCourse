using System.Linq.Expressions;
using ShawarmAPI.Models;

namespace ShawarmAPI.Repositories;

public class ShawarmaRepository : IRepository<Shawarma,Guid> {
    
    public Task<Shawarma> Add(Shawarma entity)
    {
        throw new NotImplementedException();
    }
    public Task<Shawarma?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task<Shawarma?> Get(Expression<Func<Shawarma, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<Shawarma>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<Shawarma>> GetAll(Expression<Func<Shawarma, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    public Task<Shawarma?> Update(Shawarma entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}