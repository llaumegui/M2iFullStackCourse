using System.ComponentModel.DataAnnotations;

namespace EFCore_Exercises.Models;

public class Character
{
    public int Id { get; set; }

    [Required, MinLength(5), MaxLength(200)]
    public string? NickName { get; set; }

    public int Hp { get; set; }
    public int Armor { get; set; }
    public int Damage { get; set; }
    public int HitChance
    {
        get => HitChance;
        set
        {
            if(value < 1)
                throw new ArgumentException("Value cannot be less than zero");
            if(value > 100)
                throw new ArgumentException("Value cannot be more than 100");
            HitChance = value;
        }
    }
    public DateTime DateOfCreation { get; set; }
    public int KillCount { get; set; }

    public override string ToString()
    {
        return $"{NickName} - {Hp}HP - {Armor}Armor\nDmg: {Damage} - Kills: {KillCount}\n{DateOfCreation}";
    }
}