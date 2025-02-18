using System.Diagnostics;
using System.Text;
using System.Text.Json;
using M2i.Demo.CookieSession.Models;
using Microsoft.AspNetCore.Mvc;

namespace M2i.Demo.CookieSession.Controllers
{
    public class HomeController : Controller
    {
        public const string COOKIE_NAME = "mon_contact";
        public IActionResult Index()
        {
            // On r�cup�re le cookie...
            //Request.Cookies.TryGetValue(COOKIE_NAME, out string? json);

            HttpContext.Session.TryGetValue(COOKIE_NAME, out byte[]? bytes);
            
            // Si on veut vider la session, on peut utiliser cette m�thode (en cas de d�connexion par exemple)
            // HttpContext.Session.Clear();

            if (bytes != null && bytes.Length != 0) // Si on a eu un cookie...
            {

                // On le d�s�rialise en notre viewmodel
                //var vm = JsonSerializer.Deserialize<ContactViewModel>(json);
                var vm = JsonSerializer.Deserialize<ContactViewModel>(bytes);

                // On peut envoyer une vue avec le viewmodel en donn�es
                return View(vm);

            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel vm)
        {
            // On transforme en JSON notre type C# complexe, de sorte � pouvoir le stocker en cookie
            var json = JsonSerializer.Serialize(vm);

            // On stocke un cookie 
            //Response.Cookies.Append(COOKIE_NAME, json);

            // Pour stocker dans la session, on utiliser HttpContext.Session, qui est disponible � condition d'avoir configur� Program.cs
            HttpContext.Session.Set(COOKIE_NAME, Encoding.UTF8.GetBytes(json));
            return View();
        }
    }
}
