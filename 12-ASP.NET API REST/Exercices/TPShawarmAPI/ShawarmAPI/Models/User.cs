using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShawarmAPI.Models;

[Table("users")]
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("last_name")]
    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(20, ErrorMessage = "Le nom doit faire au maximum 20 caractères.")]
    public string LastName { get; set; } = string.Empty;

    [Column("first_name")]
    [Required(ErrorMessage = "Le prenom est requis.")]
    [StringLength(20, ErrorMessage = "Le prénom doit faire au maximum 20 caractères.")]
    public string FirstName { get; set; } = string.Empty;
    
    [Column("password")]
    [JsonIgnore]
    public string? Password { get; set; }

    [Column("email")]
    [EmailAddress]
    [Required(ErrorMessage = "Le mail est requis.")]
    public string Email { get; set; }

    [Column("phone")]
    [Phone]
    [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
    public string PhoneNumber { get; set; }
    
    [Column("is_admin")]
    public bool IsAdmin { get; set; } = false;
}