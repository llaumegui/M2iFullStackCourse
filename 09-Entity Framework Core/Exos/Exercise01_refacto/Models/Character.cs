using System.ComponentModel.DataAnnotations;
namespace Exercise01_refacto.Models;

public class Character
{
    public int Id { get; set; }

    [Required, MinLength(5), MaxLength(200)]
    public string? NickName { get; set; }

    public int Hp { get; set; }
    public int Armor { get; set; }
    public int Damage { get; set; }
    public int KillCount { get; set; }
    public DateTime DateOfCreation { get; set; }

    public override string ToString()
    {
        return $"{NickName} - {Hp}HP - {Armor}Armor\nDmg: {Damage} - Kills: {KillCount}\n{DateOfCreation}";
    }
}