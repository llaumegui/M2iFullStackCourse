using Exo06.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo06.Controllers;

public class MovieController(MovieRepository repo) : Controller
{
    public IActionResult List()
    {
        var movies = repo.GetAll().ToList();
        return View(movies);
    }

    public IActionResult Form(int id)
    {
        var movie = repo.GetById(id);
        if (movie != null)
            return View(movie);

        return NotFound();
    }
    
    public IActionResult Details(int id)
    {
        var movie = repo.GetById(id);
        if (movie != null)
            return View("Form", movie);

        return NotFound();
    }

    [HttpPost]
    public IActionResult ChangeSeen(int id)
    {
        var movie = repo.GetById(id);
        if (movie != null)
            movie.Seen = !movie.Seen;
        repo.Save();
        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult ChangeFavorite(int id)
    {
        var movie = repo.GetById(id);
        if (movie != null)
            movie.Favorite = !movie.Favorite;
        repo.Save();
        return RedirectToAction("List");
    }
}