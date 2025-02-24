using ShawarmAPI.Models;

namespace ShawarmAPI.DTO.Authentification;

public class RegisterResponseDTO
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }
}