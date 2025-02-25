using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShawarmAPI.Helpers;
using ShawarmAPI.Models;
using ShawarmAPI.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShawarmAPI.Controllers;

[ApiController]
[Route("shawarmas")]
public class ShawarmaController(ShawarmaService shawarmaService, ToppingService toppingService) : ControllerBase
{
    [HttpGet("/menu")]
    [SwaggerOperation(Summary = "Get all Shawarmas from the menu")]
    [ProducesResponseType(typeof(IEnumerable<Shawarma>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<ActionResult> GetMenu()
    {
        var shawarmas = await shawarmaService.GetAll();
        return Ok(shawarmas);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create Shawarma")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateShawarma([FromBody] Shawarma shawarma)
    {
        if (await shawarmaService.Add(shawarma))
            return Ok();
        return BadRequest();
    }

    [HttpPut("{shawarmaName}")]
    [SwaggerOperation(Summary = "Update Shawarma")]
    [ProducesResponseType(typeof(Shawarma), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateShawarma(string shawarmaName, [FromBody] Shawarma shawarma)
    {
        if (User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            return Unauthorized("You can't modify this as a user.");
        
        var shawarmaDb = await shawarmaService.GetByKey(shawarmaName);
        if (shawarmaDb == null)
            return BadRequest("Shawarma doesn't exist");

        if (await shawarmaService.Update(shawarma))
            return Ok(shawarma);
        return BadRequest("Error while updating shawarma");
    }
    
    [HttpDelete("{shawarmaName}")]
    [SwaggerOperation(Summary = "Delete Shawarma")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateShawarma(string shawarmaName)
    {
        if (User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            return Unauthorized("You can't modify this as a user.");
        
        var shawarma = await shawarmaService.GetByKey(shawarmaName);
        if (shawarma == null)
            return BadRequest("Topping doesn't exist");
        
        var toppings = await toppingService.GetAll(s=>s.Shawarmas.Contains(shawarma));
        if (toppings.Any())
            foreach (var topping in toppings)
            {
                topping.Shawarmas.Remove(shawarma);
            }
        
        if (!await shawarmaService.Save())
            return BadRequest("Error while removing toppings from shawarmas");

        if (await shawarmaService.Delete(shawarmaName))
            return Ok();
        return BadRequest("Error while deleting shawarma");
    }
}
    