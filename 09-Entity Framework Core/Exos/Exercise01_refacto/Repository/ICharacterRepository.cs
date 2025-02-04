using Exercise01_refacto.Classes;
using Exercise01_refacto.Models;

namespace Exercise01_refacto.Repository;

public interface ICharacterRepository
{
    IEnumerable<Character> GetCharacters(ConditionFilter filter = ConditionFilter.None);
    Character? GetById(int id);
    bool Insert(Character character);
    bool Update(Character character);
    bool Delete(Character character);
}