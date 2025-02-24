using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShawarmAPI.DTO.Authentification;
using ShawarmAPI.Helpers;
using ShawarmAPI.Models;
using ShawarmAPI.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShawarmAPI.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly AppSettings _appSettings;
    private readonly Encryptor _encryptor;

    public UserController(UserService userService, IOptions<AppSettings> options)
    {
        _userService = userService;
        _appSettings = options.Value;
        _encryptor = new();
    }

    [HttpPost("register")]
    [SwaggerOperation(Summary = "Register new User")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RegisterResponseDTO>> Register([FromBody] RegisterRequestDTO register)
    {
        if (register.IsAdmin && User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
            return Unauthorized(new RegisterResponseDTO
                { IsSuccessful = false, ErrorMessage = "You can't create an administrator as a user." });

        if (await _userService.Get(u => u.Email == register.Email) != null)
            return BadRequest(new RegisterResponseDTO
                { IsSuccessful = false, ErrorMessage = "Email already exist !" });

        // Gestion du champ CreatedBy, si on a un JWT => utilisateur connecté
        Guid? createdBy = null;
        string? userIdClaim = User.FindFirstValue(Constants.ClaimUserId); // ou ClaimTypes.NameIdentifier
        if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out Guid userId))
        {
            createdBy = userId;
        }

        // Créer un nouvel utilisateur
        var user = new User
        {
            FirstName = register.FirstName,
            LastName = register.LastName,
            Email = register.Email,
            PhoneNumber = register.PhoneNumber,
            Password = _encryptor.Encrypt(register.Password!),
            IsAdmin = register.IsAdmin,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = createdBy
        };

        if (!await _userService.Add(user))
            return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "User Creation Failed" });

        return Ok(new RegisterResponseDTO { IsSuccessful = true, User = user });
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "User Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO login)
    {
        var user = await _userService.Get(u => u.Email == login.Email);
        
        if(user == null)
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication" });
        
        var (verified,needsUpdate) = _encryptor.Verify(user.Password!, login.Password!);
        
        if(!verified)
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication" });

        if (needsUpdate)
        {
            user.Password = _encryptor.Encrypt(user.Password!);
            await _userService.Update(user);
        }
        
        #region JWT

        string role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

        var claims = new List<Claim> // detinée à aller dans la partie Payload du JWT
        {
            new (ClaimTypes.Role, role),
            new (Constants.ClaimUserId, user.Id!.ToString()!),
            //new ("Profession", "Formateur d'exception"),
        };

        var securityKey = _appSettings.SecretKey;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_appSettings.TokenExpirationDays),
            signingCredentials: signingCredentials
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        #endregion

        return Ok(new LoginResponseDTO
        {
            IsSuccessful = true,
            Token = token,
            User = user
        });
    }
}