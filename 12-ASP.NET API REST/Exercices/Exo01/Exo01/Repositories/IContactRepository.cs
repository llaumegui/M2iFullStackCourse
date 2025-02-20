using Exo01.Models;

namespace Exo01.Repositories;

public interface IContactRepository
{
    public bool Create(Contact contact, out Guid contactId);
    public Contact Get(Guid id);
    public IEnumerable<Contact> Get(Func<Contact, bool> predicate);
    public IEnumerable<Contact> GetAll();
    public bool Delete(Contact contact);
    public bool Save();
}