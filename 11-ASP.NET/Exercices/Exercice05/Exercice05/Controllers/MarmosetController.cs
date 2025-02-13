using Exercice05.Data;
using Exercice05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice05.Controllers
{
    public class MarmosetController(ApplicationDbContext db) : Controller
    {
        Random random = new Random();
        // Pour pouvoir accéder aux marmosets, on va avoir besoin de l'accès à la fausse base de données

        public IActionResult List()
        {
            var marmosets = db.Marmosets.ToHashSet(); // On récupère l'ensemble des marmosets
            return View(marmosets); // On les envoie à la vue List.cshtml
        }

        // On obtiendra l'id de la route /Marmoset/Details/{valeur} dans les paramètres de la méthode
        // GET: /Marmoset/Details/id
        public IActionResult Details(long id)
        {
            var marmoset = db.Marmosets.FirstOrDefault(m => m.Id == id); // On cherche un marmoset via l'Id envoyé en paramètre de route
            if (marmoset == null) return View("Error"); // Si on en trouve pas, on retourne la vue d'erreur
            return View(marmoset); // Sinon, on retourne la vue Details.cshtml peuplée du marmoset trouvé
        }

        // GET: /Marmoset/CreateRandom
        public IActionResult CreateRandom()
        {
            // On génère une nouvelle instance de Marmoset, en peuplant ces champs de valeurs aléatoire (sauf pour l'ID)
            var randomMarmoset = new Marmoset()
            {
                Name = GenerateRandomName(),
                Color = GetRandomColor(),
                Age = new Random().Next(20)
            };

            // On ajoute ce nouveau marmoset à la collection des marmosets
            db.Marmosets.Add(randomMarmoset);
            db.SaveChanges();

            // On redirige vers l'action permettant l'affichage du listing de tous les marmosets
            return RedirectToAction(nameof(List));
        }

        private string GenerateRandomName()
        {
            string vowels = "aeiou";
            string consonants = "bcdfghjklmnpqrstuvwxyz";
            string result = string.Empty;
            for (int i = 1; i <= 4; i++)
                result+=i%2 == 0 ? vowels[random.Next(vowels.Length)]: consonants[random.Next(consonants.Length)];
            
            return result;
        }

        string GetRandomColor()
        {
            return typeof(Color).GetEnumValues()
                .GetValue(random.Next(Enum.GetNames(typeof(Color)).Length)).ToString();
        }

        enum Color
        {
            Blue,
            Green,
            Red,
            Yellow,
            Brown,
            Orange
        }
    }
}
