using Exo01.Models;

namespace Exo01.Repositories;

public interface IContactRepository
{
    public bool Create(Contact contact, out int contactId);
    public Contact Get(int id);
    public IEnumerable<Contact> Get(Func<Contact, bool> predicate);
    public IEnumerable<Contact> GetAll();
    public bool Delete(Contact contact);
    public bool Save();
}