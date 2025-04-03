using exo05.Data;
using exo05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace exo05.Controllers;

[ApiController]
[Route("contacts")]
public class ContactController(ApplicationDbContext db) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var contacts = db.Contacts.ToList();
        return Ok(new
        {
            Message = "contacts retrieved",
            Contacts = contacts
        });
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] Contact contact)
    {
        EntityEntry<Contact> result = db.Add(contact);
        db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = result.Entity.Id }, "contact added");
    }
    
    [HttpGet("name/{lastName}")]
    public IActionResult Get(string lastName)
    {
        var contacts = db.Contacts.Where(c => c.LastName == lastName).ToList();
        if (!contacts.Any())
            return NotFound(new
            {
                Message = "contact not found"
            });
        return Ok(new
        {
            Message = $"contact{(contacts.Count() > 1 ? "s" : "")} retrieved",
            Contacts = contacts
        });
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var contact = db.Contacts.Where(c=>c.Id == id);
        if (contact == null)
            return NotFound(new
            {
                Message = "contact not found"
            });
        return Ok(new
        {
            Message = "contact retrieved",
            Contact = contact
        });
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Contact newContact)
    {
        Contact contact = db.Contacts.Where(c => c.Id == id).FirstOrDefault();
        contact = newContact;
        db.Update(contact);
        db.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        Contact contact = db.Contacts.Where(c => c.Id == id).FirstOrDefault();
        db.Remove(contact);
        db.SaveChanges();
        return Ok();
    }
}