using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShawarmAPI.Helpers;
using ShawarmAPI.Models;
using ShawarmAPI.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShawarmAPI.Controllers;

[ApiController]
[Route("shawarmas")]
public class ToppingController(ToppingService toppingService, ShawarmaService shawarmaService) : ControllerBase
{
    [HttpPost("topping")]
    [SwaggerOperation(Summary = "Create Topping")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTopping([FromBody] Topping topping)
    {
        if (await toppingService.Add(topping))
            return Ok();
        return BadRequest();
    }

    [HttpPost("add-topping/{shawarmaName}")]
    [SwaggerOperation(Summary = "Add Topping")]
    [ProducesResponseType(typeof(Shawarma), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddTopping(string shawarmaName, string toppingName)
    {
        if (User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            return Unauthorized("You can't modify this as a user.");
        
        var topping = await toppingService.GetByKey(toppingName);
        var shawarma = await shawarmaService.GetByKey(shawarmaName);

        if (topping == null)
            return BadRequest("Ingredient doesn't exist");
        if (shawarma == null)
            return BadRequest("Shawarma doesn't exist");

        shawarma.Toppings.Add(topping);
        if (await shawarmaService.Update(shawarma))
            return Ok(shawarma);
        return BadRequest("Error while adding topping");
    }

    [HttpDelete("remove-topping/{shawarmaName}/{toppingName}")]
    [SwaggerOperation(Summary = "Remove Topping")]
    [ProducesResponseType(typeof(Shawarma), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RemoveTopping(string shawarmaName, string toppingName)
    {
        if (User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            return Unauthorized("You can't modify this as a user.");
        
        var topping = await toppingService.GetByKey(toppingName);
        var shawarma = await shawarmaService.GetByKey(shawarmaName);

        if (topping == null)
            return BadRequest("Topping doesn't exist");
        if (shawarma == null)
            return BadRequest("Shawarma doesn't exist");
        if (!shawarma.Toppings.Contains(topping))
            return BadRequest("Topping isn't in the list of toppings");

        shawarma.Toppings.Remove(topping);
        if (await shawarmaService.Update(shawarma))
            return Ok(shawarma);
        return BadRequest("Error while removing topping");
    }

    [HttpDelete("{toppingName}")]
    [SwaggerOperation(Summary = "Delete Topping")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteTopping(string toppingName)
    {
        if (User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            return Unauthorized("You can't modify this as a user.");
        
        var topping = await toppingService.GetByKey(toppingName);
        if (topping == null)
            return BadRequest("Topping doesn't exist");
        
        var shawarmas = await shawarmaService.GetAll(s=>s.Toppings.Contains(topping));
        if (shawarmas.Any())
            foreach (var shawarma in shawarmas)
            {
                shawarma.Toppings.Remove(topping);
            }
        
        if (!await shawarmaService.Save())
            return BadRequest("Error while removing toppings from shawarmas");

        if (await toppingService.Delete(toppingName))
            return Ok();
        return BadRequest("Error while deleting topping");
    }
}