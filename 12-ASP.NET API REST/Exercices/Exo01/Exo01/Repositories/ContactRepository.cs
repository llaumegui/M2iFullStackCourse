using Exo01.Data;
using Exo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01.Repositories;

public class ContactRepository(ApplicationDbContext db) : IContactRepository
{
    public bool Create(Contact contact, out Guid contactId)
    {
        var dbContact = db.Add(contact);
        contactId = dbContact.Entity.Id;
        return dbContact.State == EntityState.Added;
    }
    
    public Contact Get(Guid id)=>db.Contacts.FirstOrDefault(c=>c.Id == id);

    public IEnumerable<Contact> Get(Func<Contact, bool> predicate)=>db.Contacts.Where(predicate);

    public IEnumerable<Contact> GetAll()=>db.Contacts;

    public bool Delete(Contact contact)
    {
        var dbContact = db.Remove(contact);
        return dbContact.State == EntityState.Deleted;
    }

    public bool Save() => db.SaveChanges() > 0;
}