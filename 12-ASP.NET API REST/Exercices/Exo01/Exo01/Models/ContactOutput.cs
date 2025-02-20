namespace Exo01.Models;

public class ContactOutput
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public char Gender { get; init; }
    public int Age { get; init; }
    
    public string? Email { get; init; }
    public string? Phone { get; init; }
}