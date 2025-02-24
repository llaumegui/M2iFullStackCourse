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
    public string LastName { get; set; } = string.Empty;

    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;
    
    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? PhoneNumber { get; set; }
    
    [Column("password")]
    [JsonIgnore]
    public string? Password { get; set; }
    
    [Column("is_admin")]
    public bool IsAdmin { get; set; } = false;
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("created_by")]
    public Guid? CreatedBy { get; set; }
}