using Exo01.Models;
using Exo01.Repositories;
using Exo01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exo01.Controllers;

[ApiController]
[Route("contacts")]
public class ContactController(ContactRepository cr) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var contacts = cr.GetAll();
        return Ok(new
        {
            Message = "contacts retrieved",
            Contacts = contacts
        });
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var contact = cr.Get(id);
        if (contact == null)
            return NotFound(new 
            {
                Message = "contact not found"
            });
        return Ok(new
        {
            Message = "contact retrieved",
            Contacts = contact
        });
    }

    [HttpGet("name/{lastName}")]
    public IActionResult Get(string lastName)
    {
        var contacts = cr.Get(c=>c.LastName == lastName).ToList();
        if (!contacts.Any())
            return NotFound(new 
            {
                Message = "contact not found"
            });
        return Ok(new
        {
            Message = $"contact{(contacts.Count()>1?"s":"")} retrieved",
            Contacts = contacts
        });
    }

    [HttpPost]
    public IActionResult Post(Contact contact)
    {
        if(cr.Create(contact, out int contactId))
            return CreatedAtAction(nameof(Get), new { id = contactId }, "contact added");
        return BadRequest(
            new
            {
                Message = "Bad Request"
            });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Contact newContact)
    {
        var contact = cr.Get(id);
        
        if(contact == null)
            return NotFound(new
            {
                Message = "contact not found"
            });
        if(contact.FirstName != newContact.FirstName)
            contact.FirstName = newContact.FirstName;
        if(contact.LastName != newContact.LastName)
            contact.LastName = newContact.LastName;
        if(contact.Gender != newContact.Gender)
            contact.Gender = newContact.Gender;
        if(contact.Birthday != newContact.Birthday)
            contact.Birthday = newContact.Birthday;
        if(contact.Email != newContact.Email)
            contact.Email = newContact.Email;
        if(contact.Phone != newContact.Phone)
            contact.Phone = newContact.Phone;
        
        cr.Save();
        return CreatedAtAction(nameof(Get), new { id = contact.Id }, "contact updated");
    }
}