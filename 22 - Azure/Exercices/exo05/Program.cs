using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using exo05.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AzureKeyVault
const string secretName = "exo05-connectionstring";
var keyVaultName = "gl-vault";
var kvUri = $"https://{keyVaultName}.vault.azure.net";

var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
var secret = await client.GetSecretAsync(secretName);
#endregion

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    if (secret.HasValue)
        options.UseSqlServer(secret.Value.Value);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactAPI");
    options.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();