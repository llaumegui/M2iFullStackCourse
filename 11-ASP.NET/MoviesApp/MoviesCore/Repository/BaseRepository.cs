using Microsoft.EntityFrameworkCore;
using MoviesCore.Data;
using MoviesCore.Interfaces;

namespace MoviesCore.Repository;

public abstract class BaseRepository<TKey, T> : IRepository<TKey, T> where T : class
{
    private ApplicationDbContext? _context = new();
    
    private ApplicationDbContext CurrentContext => _context ??= new();
    protected DbSet<T> CurrentDbSet => GetDbSet(CurrentContext);
    
    public abstract IEnumerable<T> GetAll();
    public abstract T? GetById(TKey id);
    protected abstract DbSet<T> GetDbSet(ApplicationDbContext context);

    public void Add(T item)
    {
        CurrentDbSet.Add(item);
    }

    public void Save()
    {
        if (_context == null)
            return;

        _context.SaveChanges();
        _context.Dispose();
        _context = null;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (_context != null) await _context.DisposeAsync();
    }
}