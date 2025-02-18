using System.ComponentModel.DataAnnotations;

namespace Exo01.Models;


public class Contact
{
    [Key]
    public int Id { get; set; }
    
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ]$")]
    [StringLength(20)]
    public required string FirstName { get; set; }
    
    [RegularExpression(@"^[A-Z]$")]
    [StringLength(20)]
    public required string LastName { get; set; }
    
    [RegularExpression(@"^[MFN]$")]
    public required string Gender { get; set; }
    
    [DataType(DataType.Date),
    Range(typeof(DateTime), "1/1/1910", "1/1/2025")]
    public required DateTime Birthday { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [Phone]
    public string? Phone { get; set; }
    
    public int Age => DateTime.Now.Year - Birthday.Year - ((DateTime.Now.Month - Birthday.Month)<0?1:0);
    public string? FullName => $"{FirstName} {LastName}";
    
}