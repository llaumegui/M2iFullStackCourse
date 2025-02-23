using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShawarmAPI.Data;
using ShawarmAPI.Repositories;
using ShawarmAPI.Services;

namespace ShawarmAPI.Helpers;

public static class DependencyInjections
{
    public static void InjectDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.AddSwagger();

        builder.Services.AddDbContext<ApplicationDbContext>
        (
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        );

        builder.AddRepositories();

        builder.AddServices();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        builder.AddAuthentification();
    }

    private static void AddSwagger(this WebApplicationBuilder builder)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(x =>
        {
            x.EnableAnnotations();
            x.SwaggerDoc("v1", new() { Title = "ShawarmaAPI", Version = "v1" });
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter you Bearer token in the format **Bearer {token}** to access this API",
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }

    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IngredientRepository>();
        builder.Services.AddScoped<ShawarmaRepository>();
        builder.Services.AddScoped<UserRepository>();
    }

    private static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<FirstRunService>();

        builder.Services.AddScoped<IngredientService>();
        builder.Services.AddScoped<ShawarmaService>();
        builder.Services.AddScoped<UserService>();
    }

    private static void AddAuthentification(this WebApplicationBuilder builder)
    {
        var appsettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appsettings!.SecretKey);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}