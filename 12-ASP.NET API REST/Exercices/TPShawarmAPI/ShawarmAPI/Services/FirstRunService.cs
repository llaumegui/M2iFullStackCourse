using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Data;
using ShawarmAPI.Helpers;
using ShawarmAPI.Models;

namespace ShawarmAPI.Services;

public class FirstRunService(IServiceScopeFactory scopeFactory) : IHostedService
{
    private readonly Encryptor _encryptor = new();

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var scope = scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        // Applique les migrations automatiquement au démarrage
        await dbContext.Database.MigrateAsync(cancellationToken);

        // Vérifie s'il existe déjà un administrateur
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.IsAdmin, cancellationToken);
        if (user == null)
        {
            user = new User
            {
                Email = "admin@admin.com",
                IsAdmin = true,
                Password = _encryptor.Encrypt("P@ssWord!12"),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = null
            };

            // Ajoute l'administrateur racine à la base de données
            await dbContext.Users.AddAsync(user, cancellationToken);
            if (await dbContext.SaveChangesAsync(cancellationToken) <= 0)
            {
                throw new Exception("Root Admin could not be created");
            }
        }
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}