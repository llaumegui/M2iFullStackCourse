using Exercise02.Data;
using Exercise02.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exercise02.Repositories;

public class ClientRepository(ApplicationDbContext db) : IRepository<Client,int>
{
    public bool Add(Client obj)
    {
        EntityEntry<Client> entry = db.Entry(obj);
        return db.SaveChanges() == 1;
    }

    public Client? GetById(int id) => db.Clients.FirstOrDefault(r => r.Id == id);
    
    public Client? Get(Func<Client, bool> predicate)=> db.Clients.FirstOrDefault(predicate);
    
    public IEnumerable<Client> GetAll() => db.Clients;
    
    public IEnumerable<Client> GetAll(Func<Client, bool> predicate) => db.Clients.Where(predicate);

    public bool Delete(int id)
    {
        var client = GetById(id);
        if (client == null)
            return false;

        db.Clients.Remove(client);
        return Save();
    }

    public bool Save() => db.SaveChanges() > 0;
}