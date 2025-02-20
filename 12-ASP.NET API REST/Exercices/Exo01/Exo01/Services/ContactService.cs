using Exo01.Models;
using Exo01.Repositories;

namespace Exo01.Services;

public class ContactService(ContactRepository cr)
{
    private Contact _workItem;
    
    public Contact ToContact(ContactInput input)
    {
        return new()
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Gender = input.Gender,
            Birthday = input.Birthday,
            Email = input.Email,
            Phone = input.Phone,
        };
    }
    
    public ContactOutput ToContactOutput(Contact contact)
    {
        return new ContactOutput()
        {
            Id = contact.Id,
            FullName = contact.FullName,
            Gender = contact.Gender,
            Age = contact.Age,
            Email = contact.Email,
            Phone = contact.Phone
        };
    }

    public List<ContactOutput> ToContactOutput(List<Contact> contacts)
    {
        List<ContactOutput> output = new List<ContactOutput>();
        foreach (var contact in contacts)
        {
            output.Add(ToContactOutput(contact));
        }
        return output;
    }
    
    public bool Create(ContactInput contact, out Guid contactId)
    {        
        cr.Create(ToContact(contact), out contactId);
        return Save();
    }
    
    public bool SetWorkItem(Guid id, out Contact contact)
    {
        _workItem = cr.Get(id);
        contact = _workItem;
        return _workItem != null;
    }
    
    
    public ContactOutput Get(Guid id)=>ToContactOutput(cr.Get(id));

    public List<ContactOutput> Get(Func<Contact, bool> predicate)
    {
        return ToContactOutput(cr.Get(predicate).ToList());   
    }

    public List<ContactOutput> GetAll()=>ToContactOutput(cr.GetAll().ToList());

    public bool Delete()
    {
        cr.Delete(_workItem);
        return Save();
    }

    public bool Save()
    {
        _workItem = null;
        return cr.Save();
    }
    
    public bool Update(ContactInput newContact)
    {
        if(_workItem.FirstName != newContact.FirstName)
            _workItem.FirstName = newContact.FirstName;
        if(_workItem.LastName != newContact.LastName)
            _workItem.LastName = newContact.LastName;
        if(_workItem.Gender != newContact.Gender)
            _workItem.Gender = newContact.Gender;
        if(_workItem.Birthday != newContact.Birthday)
            _workItem.Birthday = newContact.Birthday;
        if(_workItem.Email != newContact.Email)
            _workItem.Email = newContact.Email;
        if(_workItem.Phone != newContact.Phone)
            _workItem.Phone = newContact.Phone;

        return Save();
    }
}