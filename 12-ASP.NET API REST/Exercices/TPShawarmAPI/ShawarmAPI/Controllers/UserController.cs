using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShawarmAPI.Helpers;
using ShawarmAPI.Services;

namespace ShawarmAPI.Controllers;

[ApiController]
[Route("authentification")]
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
    
    
}