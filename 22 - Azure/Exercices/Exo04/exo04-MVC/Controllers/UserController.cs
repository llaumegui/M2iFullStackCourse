using exo04_MVC.Data;
using exo04_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace exo04_MVC.Controllers;

public class UserController(AppDbContext db) : Controller
{
    Random _rdm = new();
    string _chars = "ABCDEFGHIJFKLMNOPQRSTUVWXYZ0123456789";

    string Generate(int length)
    {
        return new string(Enumerable.Repeat(_chars, length).Select(s => s[_rdm.Next(s.Length)]).ToArray());
    }

    public IActionResult Index()
    {
        var users = db.Users.ToList();
        return View(users);
    }

    public IActionResult Create()
    {
        var firstName = Generate(_rdm.Next(10));
        var lastName = Generate(_rdm.Next(10));

        db.Users.Add(new User
        {
            FirstName = firstName,
            LastName = lastName
        });

        db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(Guid id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}