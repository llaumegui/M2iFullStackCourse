using Exercise01_refacto.Models;
using Exercise01_refacto.Repository;

namespace Exercise01_refacto.Classes;

public class AppController(IHM display)
{
    private IHM _display = display;
    private CharacterRepository _repository = new CharacterRepository();

    public void CreateCharacter()
    {
        string nickName = _display.GetInput("Saisissez un pseudo: ");
        int hp = int.Parse(_display.GetInput("Saisissez le nombre de points de vie: "));
        int armor = int.Parse(_display.GetInput("Saisissez le nombre de points d'armure: "));
        int damage = int.Parse(_display.GetInput("Saisissez les points de dégâts: "));
        int kills = int.Parse(_display.GetInput("Saisissez le nombre de kills: "));

        var newChar = new Character()
        {
            NickName = nickName,
            Hp = hp,
            Armor = armor,
            Damage = damage,
            KillCount = kills,
            DateOfCreation = DateTime.Now
        };

        _display.ShowOutput($"L'opération a " +
                            (_repository.Insert(newChar) ? "réussi" : "échoué"));
    }

    public void UpdateCharacter()
    {
        int id = int.Parse(_display.GetInput("Saisissez l'Id du personnage: "));
        var character = _repository.GetById(id);
        if (character == null)
        {
            _display.ShowOutput("L'id du personnage n'existe pas");
            return;
        }

        bool parseSuccess = false;

        string nickName = _display.GetInput("Saisissez un Pseudo (laisser vide si on ne modifie pas): ");
        character.NickName = nickName == string.Empty ? character.NickName : nickName;

        parseSuccess = int.TryParse(
            _display.GetInput("Saisissez le nombre de points de vie (laisser vide si on ne modifie pas): "),
            out int hp);
        character.Hp = parseSuccess ? hp : character.Hp;

        parseSuccess = int.TryParse(
            _display.GetInput("Saisissez les points d'armure (laisser vide si on ne modifie pas): "),
            out int armor);
        character.Armor = parseSuccess ? armor : character.Armor;

        parseSuccess = int.TryParse(
            _display.GetInput("Saisissez les points de dégâts (laisser vide si on ne modifie pas): "),
            out int damage);
        character.Damage = parseSuccess ? damage : character.Damage;

        parseSuccess = int.TryParse(
            _display.GetInput("Saisissez le nombre de kills (laisser vide si on ne modifie pas): "),
            out int kills);
        character.KillCount = parseSuccess ? kills : character.KillCount;

        _display.ShowOutput($"L'opération a " +
                            (_repository.Update(character) ? "réussi" : "échoué"));
    }

    public void ShowCharacters(ConditionFilter filter = ConditionFilter.None)
    {
        var characters = _repository.GetCharacters(filter);
        foreach (var character in characters)
        {
            _display.ShowOutput(character.ToString());
        }
    }

    public void HitCharacter()
    {
        int idAttacker = int.Parse(_display.GetInput("Saisissez l'Id de l'attaquant: "));
        var attacker = _repository.GetById(idAttacker);
        if (attacker == null)
        {
            _display.ShowOutput("L'id du personnage n'existe pas");
            return;
        }

        int idAttacked = int.Parse(_display.GetInput("Saisissez l'Id de l'attqué: "));
        var attacked = _repository.GetById(idAttacked);
        if (attacked == null)
        {
            _display.ShowOutput("L'id du personnage n'existe pas");
            return;
        }

        int trueDamage = attacker.Damage - attacked.Armor;
        trueDamage = trueDamage < 0 ? 0 : trueDamage;
        _display.ShowOutput($"L'attaque de {attacker.NickName} a infligé" +
                            $" {trueDamage} dégâts à {attacked.NickName}!");

        attacked.Hp -= trueDamage;

        if (attacked.Hp <= 0)
        {
            _display.ShowOutput($"{attacked.NickName} est mort!");
            attacker.KillCount++;
            KillCharacter(attacked);

            _repository.Update(attacker);
        }
        else
            _repository.Update(attacked);
    }

    private void KillCharacter(Character character) { _repository.Delete(character); }
}