using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ShawarmAPI.Validators;

namespace ShawarmAPI.DTO.Authentification;

public class RegisterRequestDTO
{
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(20, ErrorMessage = "Le nom doit faire au maximum 20 caractères.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(20, ErrorMessage = "Le prénom doit faire au maximum 20 caractères.")]
    public string FirstName { get; set; } = string.Empty;
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Phone Number is required.")]
    [Phone(ErrorMessage = "Phone Number is invalid")]
    public string? PhoneNumber { get; set; }
    
    public bool IsAdmin { get; set; } = false;
    
    [DataType(DataType.Password)]
    [PasswordValidator]
    public string Password { get; set; }
}