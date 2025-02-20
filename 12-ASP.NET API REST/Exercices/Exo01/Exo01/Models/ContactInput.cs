using System.ComponentModel.DataAnnotations;

namespace Exo01.Models;

public class ContactInput
{
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ]{2,19}$")]
    public required string FirstName { get; set; }
    
    [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ]{2,19}$")]
    public required string LastName { get; set; }
    
    [RegularExpression(@"^[MFN]$")]
    public required char Gender { get; set; }
    
    [DataType(DataType.Date),
     Range(typeof(DateTime), "1910-1-1", "2025-1-1")]
    public required DateTime Birthday { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [RegularExpression(@"^[0-9]{10}$")]
    public string? Phone { get; set; }
}