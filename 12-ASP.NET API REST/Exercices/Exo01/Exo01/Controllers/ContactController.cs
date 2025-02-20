using Exo01.Models;
using Exo01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exo01.Controllers;

[ApiController]
[Route("contacts")]
public class ContactController(ContactService cs) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var contacts = cs.GetAll();
        return Ok(new
        {
            Message = "contacts retrieved",
            Contacts = contacts
        });
    }
    
    [HttpPost]
    public IActionResult Post(ContactInput contactInput)
    {
        if (cs.Create(contactInput, out Guid contactId))
            return CreatedAtAction(nameof(Get), new { id = contactId }, "contact added");
        return BadRequest(
            new
            {
                Message = "Bad Request"
            });
    }
    
    [HttpGet("name/{lastName}")]
    public IActionResult Get(string lastName)
    {
        var contacts = cs.Get(c => c.LastName == lastName).ToList();
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
        var contact = cs.Get(id);
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
    public IActionResult Put(Guid id, [FromBody] ContactInput newContact)
    {
        if(!cs.SetWorkItem(id,out _))
            return NotFound();
        
        if (cs.Update(newContact))
            return CreatedAtAction(nameof(Get), new { id = id }, "contact updated");

        return BadRequest(
            new
            {
                Message = "Bad Request"
            });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        if (!cs.SetWorkItem(id, out _))
            return NotFound();
        if (cs.Delete())
            return Ok();

        return BadRequest();
    }
}