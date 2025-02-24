using System.ComponentModel.DataAnnotations;

namespace ShawarmAPI.DTO.Authentification;

public class LoginRequestDTO
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; }
    
    [DataType(DataType.Password)]
    [Required]
    public string? Password { get; set; }
}