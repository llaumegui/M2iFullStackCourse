using System.ComponentModel.DataAnnotations;

namespace exo05.Models;

public class Contact
{
    [Key]
    public Guid Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required char Gender { get; set; }
    
    public required DateTime Birthday { get; set; }
    
    public int Age => DateTime.Now.Year - Birthday.Year - ((DateTime.Now.Month - Birthday.Month)<0?1:0);
    public string FullName => $"{FirstName} {LastName}";
    
}