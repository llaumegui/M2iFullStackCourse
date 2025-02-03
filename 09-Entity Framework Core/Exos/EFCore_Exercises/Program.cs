using EFCore_Exercises.Data;
using EFCore_Exercises.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

string Menu()
{
    Console.WriteLine(
        "  ____\n |  _ \\ ___ _ __ ___  ___  __  __ __  _  __ _  __ _  ___ \n | |_) / _ \\ '__/ __|/ _ \\|  \\| ||  \\| |/ _` |/ _` |/ _ \\\n |  __/  __/ |  \\__ \\ (_) | |\\  || |\\  | (_| | (_| |  __/\n |_|   \\___|_|  |___/\\___/|_| \\_||_| \\_|\\__,_|\\__, |\\___|\n                                       \t      |___/");
    Console.WriteLine("1. Créer un personnage");
    Console.WriteLine("2. Mettre à jour un personnage");
    Console.WriteLine("3. Afficher tous les personnages");
    Console.WriteLine("4. Taper un personnage");
    Console.WriteLine("5. Afficher les personnages avec des PVs supérieur à la moyenne");
    Console.WriteLine("0. Quitter");

    Console.Write("Votre choix: ");
    return Console.ReadLine();
}

using var context = new ApplicationDbContext();
while (true)
{
    string choice = Menu();
    switch (choice)
    {
        case "1":
            CreateCharacter();
            break;
        case "2":
            UpdateCharacter();
            break;
        case "3":
            ShowCharacters();
            break;
        case "4":
            HitCharacter();
            break;
        case "5":
            ShowCharacters(ShowCondition.HpOverAverage);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Une erreur est survenue");
            break;
    }

    Console.ReadLine();
    Console.Clear();
}

void CreateCharacter()
{
    Console.Write("Saisissez un Pseudo: ");
    string nickName = Console.ReadLine();
    Console.Write("Saisissez le nombre de points de vie: ");
    int hp = int.Parse(Console.ReadLine());
    Console.Write("Saisissez les points d'armure: ");
    int armor = int.Parse(Console.ReadLine());
    Console.Write("Saisissez les points de dégâts: ");
    int damage = int.Parse(Console.ReadLine());
    Console.Write("Saisissez le nombre de kills: ");
    int kills = int.Parse(Console.ReadLine());

    var newChar = new Character()
    {
        NickName = nickName,
        Hp = hp,
        Armor = armor,
        Damage = damage,
        KillCount = kills,
        DateOfCreation = DateTime.Now
    };

    context.Characters.Add(newChar);
    context.SaveChanges();
}

void UpdateCharacter()
{
    bool parseSuccess;

    Console.Write("Saisissez l'Id du personnage a modifier: ");
    int.TryParse(Console.ReadLine(), out int id);
    var character = context.Characters.FirstOrDefault(c => c.Id == id);
    if (character == null)
    {
        Console.WriteLine("L'id du personnage n'existe pas");
        return;
    }

    Console.Write("Saisissez un Pseudo (laisser vide si on ne modifie): ");
    string nickName = Console.ReadLine();
    character.NickName = nickName == string.Empty ? character.NickName : nickName;
    Console.Write("Saisissez le nombre de points de vie(laisser vide si on ne modifie): ");
    parseSuccess = int.TryParse(Console.ReadLine(), out int hp);
    character.Hp = parseSuccess ? hp : character.Hp;

    Console.Write("Saisissez les points d'armure: ");
    parseSuccess = int.TryParse(Console.ReadLine(), out int armor);
    character.Armor = parseSuccess ? armor : character.Armor;

    Console.Write("Saisissez les points de dégâts: ");
    parseSuccess = int.TryParse(Console.ReadLine(), out int damage);
    character.Damage = parseSuccess ? damage : character.Damage;

    Console.Write("Saisissez le nombre de kills: ");
    parseSuccess = int.TryParse(Console.ReadLine(), out int kills);
    character.KillCount = parseSuccess ? kills : character.KillCount;

    context.SaveChanges();
}

void HitCharacter()
{
    bool parseSuccess;

    Console.Write("Saisissez l'Id du personnage attaquant: ");
    int idAttacking = int.Parse(Console.ReadLine());
    var attackingChar = context.Characters.FirstOrDefault(c => c.Id == idAttacking);
    if (attackingChar == null)
    {
        Console.WriteLine("L'id du personnage n'existe pas");
        return;
    }

    Console.Write("Saisissez l'Id du personnage attaqué: ");
    int idAttacked = int.Parse(Console.ReadLine());
    var attackedChar = context.Characters.FirstOrDefault(c => c.Id == idAttacked);
    if (attackedChar == null)
    {
        Console.WriteLine("L'id du personnage n'existe pas");
        return;
    }

    int trueDamage = attackingChar.Damage - attackedChar.Armor;
    trueDamage = trueDamage < 0 ? 0 : trueDamage;
    Console.WriteLine($"L'attaque de {attackingChar.NickName} a infligé" +
                      $" {trueDamage} dégâts à {attackedChar.NickName}!");

    attackedChar.Hp -= trueDamage;

    if (attackedChar.Hp <= 0)
    {
        Console.WriteLine($"{attackedChar.NickName} est mort!");
        attackingChar.KillCount++;
        KillCharacter(attackedChar);
    }

    context.SaveChanges();
}

void ShowCharacters(ShowCondition condition = ShowCondition.None)
{
    var avg = context.Characters.Average(c => c.Hp+c.Armor);
    var characters = condition switch
    {
        ShowCondition.HpOverAverage => context.Characters.Where(c => c.Hp + c.Armor > avg).ToList(),
        _ => context.Characters.ToList()
    };
    characters.ForEach(Console.WriteLine);
}


void KillCharacter(Character character) { context.Characters.Remove(character); }

public enum ShowCondition
{
    HpOverAverage,
    None,
}