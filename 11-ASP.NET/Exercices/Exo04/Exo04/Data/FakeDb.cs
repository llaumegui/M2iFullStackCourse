using Exo04.Models;

namespace Exo04.Data;

public class FakeDb
{
    public readonly HashSet<Marmoset> Marmosets = new()
    {
        new Marmoset() { Id = 1, Name = "Baba", Age = 8 },
        new Marmoset() { Id = 2, Name = "Bebou", Age = 4, Race = "Moche" }
    };
}