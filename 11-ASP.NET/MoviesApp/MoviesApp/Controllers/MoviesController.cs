using MoviesCore.Models;
using MoviesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [Route("")]
    [Route("movies/")]
    public IActionResult List()
    {
        return View(_movieService.GetAllMovies());
    }

    public IActionResult Form(Movie item)
    {
        ViewData["ActionId"] = ControllerContext.ActionDescriptor.Id;
        return View(item);
    }
    
    public IActionResult Create()
    {
        return View(nameof(Form), new Movie());
    }
    
    public IActionResult Edit(int movieId)
    {
        var item = _movieService.GetMovieById(movieId);
        if (item == null)
        {
            return NotFound();
        }
        return View(nameof(Form), item);
    }

    public IActionResult SubmitForm(Movie movie)
    {
        try
        {
            _movieService.AddMovie(movie);
            return RedirectToAction(nameof(List));
        }
        catch (DbUpdateException e)
        {
            ViewData["Error"] = e.InnerException?.Message;
            return View(nameof(Form));
        }
    }
}