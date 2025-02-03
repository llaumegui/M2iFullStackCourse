namespace EFCore_Demo.Models;

public class Livre
{
    public int Id { get; set; }

    public string? Titre { get; set; }

    public string? Description { get; set; }

    public string? Auteur { get; set; }

    public DateTime DatePublication { get; set; }

}