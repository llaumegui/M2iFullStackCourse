using Exercice06.Models;
using Exercice06.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercice06.Controllers;

public class MovieController(MovieRepository mr) : Controller
{
    public IActionResult List()
    {
        var movies = mr.Read().ToHashSet();
        return View(movies);
    }

    public IActionResult Create()
    {
        ViewBag.FormMode = "Create";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create([Bind("Title")]Movie movie)
    {
        if(!ModelState.IsValid)
            return View("Form", movie);
        
        if(mr.Create(movie))
            return RedirectToAction(nameof(List));
        
        return View("Form", movie);
    }

    public IActionResult Details(int id)
    {
        var movie = mr.Read(id);
        return View("Form",movie);
    }
    
}