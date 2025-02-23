using Microsoft.AspNetCore.Mvc;
using ShawarmAPI.Services;

namespace ShawarmAPI.Controllers;

[ApiController]
[Route("shawarmas")]
public class ShawarmaController(ShawarmaService shawarmaService, IngredientService ingredientService ) : ControllerBase
{
    
}