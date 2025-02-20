using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Data;
using ShawarmAPI.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShawarmAPI.Helpers;

public static class DependencyInjections
{
    public static void InjectDependencies(this WebApplicationBuilder builder)
    {
        
        builder.AddSwagger();

        builder.AddRepositories();

        builder.AddServices();
        
        builder.AddAuthentification();
        
        
        // TODO : MOVE CODE BELOW
        
        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>
        (
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        );
        builder.Services.AddScoped<IngredientRepository>();
        builder.Services.AddScoped<ShawarmaRepository>();
        builder.Services.AddScoped<UserRepository>();
    }

    private static void AddSwagger(this WebApplicationBuilder builder)
    {
        
    }

    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        
    }

    private static void AddServices(this WebApplicationBuilder builder)
    {
        
    }

    private static void AddAuthentification(this WebApplicationBuilder builder)
    {
        
    }
}