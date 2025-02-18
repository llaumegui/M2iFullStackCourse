// builder => sert � construire et configurer l'application
using Demo01.Data;
using Demo01.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajout de services.
// Des classes qui donnent des fonctionnalit�s r�utilisables dans l'application
// Ex : pour la BDD, pour EfCore, Repositories, Logique M�tier, ...

builder.Services.AddControllersWithViews(); // Obligatoire en MVC

// Le cycle de vie Transient, le plus court, sert � rendre les d�pendances disponibles lors du traitement de e la requ�te par un contr�leur. Elle sont lib�r�es par la suite
//builder.Services.AddTransient();

// Le cycle de vie Scope va �tre utile pour rendre les d�pendances communes entre plusieurs contr�leurs, de sorte � ce que celles-ci puissent partager au besoin des informations durant la requ�te.
//builder.Services.AddScoped();

// Le cycle de vie Singleton va permettre de rendre disponible une d�pendance entre les requ�tes. Celle-ci va �tre partag�e, une fois cr��e, par tous les �l�ments de notre application jusqu'� son arret
//builder.Services.AddSingleton();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddScoped<IRepository<Cat>, CatRepository>();
//builder.Services.AddScoped<IRepository<Dog>, DogRepository>();

//m�thode qui passe d'une application "en construction" � une application pr�te
var app = builder.Build();

// Configure the HTTP request pipeline.
//Configuration des Middleware

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //app.UseHsts(); // utilis� pour le https
}

//app.UseHttpsRedirection(); // utilis� pour le https
app.UseStaticFiles(); // => wwwroot (css, js, images, favicon, ...)

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{action=Index}/{controller=Home}/{id?}"); // change l'ordre dans la route
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ajout d'une 2e configuration avec une route "/test" qui redirige vers Privacy
//app.MapControllerRoute(
//    name: "customRoute",
//    pattern: "test",
//    new
//    {
//        Controller = "Home",
//        Action = "Privacy"
//    });

// lancer l'application une fois configur�e
app.Run();
