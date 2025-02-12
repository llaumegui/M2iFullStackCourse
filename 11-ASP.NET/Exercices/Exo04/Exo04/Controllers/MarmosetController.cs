using Exo04.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exo04.Controllers;

public class MarmosetController(FakeDb db) : Controller
{
    // GET
    public IActionResult List()
    {
        return View(db.Marmosets);
    }

    public IActionResult Details(int id)
    {
        var marmoset = db.Marmosets.FirstOrDefault(m=>m.Id==id);
        if(marmoset != null)
            return View(marmoset);
        else
            return NotFound();
    }
}