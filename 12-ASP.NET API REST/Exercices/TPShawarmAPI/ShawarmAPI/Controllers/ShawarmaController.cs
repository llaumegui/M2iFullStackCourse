using Microsoft.AspNetCore.Mvc;
using ShawarmAPI.Services;

namespace ShawarmAPI.Controllers;

[ApiController]
[Route("shawarmas")]
public class ShawarmaController(IShawarmaService shawarmaService, IIngredientService ingredientService ) : ControllerBase
{
    
}