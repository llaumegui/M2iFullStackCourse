using Microsoft.EntityFrameworkCore;
using ShawarmAPI.Data;
using ShawarmAPI.Helpers;
using ShawarmAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependencies();
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();