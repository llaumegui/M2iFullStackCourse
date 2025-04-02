using exo04_MVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    //var password = builder.Configuration["DB_PASSWORD"];
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default").Replace("DB_PASSWORD", password));
    options.UseSqlServer("Server=tcp:gl-server.database.windows.net,1433;Initial Catalog=gl-exo04;Persist Security Info=False;User ID=m2i.dotnet6@utopios.onmicrosoft.com;Password={MY_PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Password;");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}");

app.Run();