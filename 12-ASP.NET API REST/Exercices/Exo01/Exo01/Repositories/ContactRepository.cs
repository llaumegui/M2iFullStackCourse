using Exo01.Data;
using Exo01.Models;

namespace Exo01.Repositories;

public class ContactRepository(ApplicationDbContext db) : IContactRepository
{
    public bool Create(Contact contact, out int contactId)
    {        
        contactId = db.Add(contact).Entity.Id;
        return Save();
    }
    
    public Contact Get(int id)=>db.Contacts.FirstOrDefault(c=>c.Id == id);

    public IEnumerable<Contact> Get(Func<Contact, bool> predicate)=>db.Contacts.Where(predicate);

    public IEnumerable<Contact> GetAll()=>db.Contacts;

    public bool Delete(Contact contact)
    {
        db.Remove(contact);
        return Save();
    }

    public bool Save() => db.SaveChanges() > 0;
}