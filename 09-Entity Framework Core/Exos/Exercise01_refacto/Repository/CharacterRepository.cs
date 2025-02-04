using Exercise01_refacto.Classes;
using Exercise01_refacto.Data;
using Exercise01_refacto.Models;

namespace Exercise01_refacto.Repository;

public class CharacterRepository : ICharacterRepository
{
    public IEnumerable<Character> GetCharacters(ConditionFilter filter = ConditionFilter.None)
    {
        using ApplicationDbContext context = new();
        IEnumerable<Character> characters = null;
        switch (filter)
        {
            case ConditionFilter.HpOverAverage:
                var avg = context.Characters.Average(c => c.Hp+c.Armor);
                characters = context.Characters.Where(c => c.Hp + c.Armor > avg);
                break;
            default:
                characters = context.Characters;
                break;
        }

        return characters.ToList();
    }

    public Character? GetById(int id)
    {
        using ApplicationDbContext context = new();
        return context.Characters.FirstOrDefault(x => x.Id == id);
    }

    public bool Insert(Character character)
    {
        using ApplicationDbContext context = new();
        context.Characters.Add(character);
        return context.SaveChanges()!=0;
    }

    public bool Update(Character character)
    {
        using ApplicationDbContext context = new();
        context.Characters.Update(character);
        return context.SaveChanges()!=0;
    }

    public bool Delete(Character character)
    {
        using var context = new ApplicationDbContext();
        context.Characters.Remove(character);
        return context.SaveChanges()!=0;
    }
    
}