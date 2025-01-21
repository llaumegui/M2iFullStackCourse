namespace Demo01.Classes;

public class Dinosaur
{
    private string? _name;
    private int _age;
    private string? _species;
    private float _weight;
    private int _nbrLegs;
    private Diet? _diet;

    #region Accessors
    public string? Name { get => _name; set => _name = value; }
    public int Age { get => _age; set => _age = value; }
    public string? Species { get => _species; set => _species = value; }
    public float Weight { get => _weight; set => _weight = value < 0 ? 100 : value; }
    public int NbrLegs { get => _nbrLegs; set => _nbrLegs = value; }
    public Diet? Diet { get => _diet; set => _diet = value; }
    #endregion

    public Dinosaur()
    {
        Name = "Default";
        Species = "Default";
        Age = 120;
        Weight = 100;
    }
    public Dinosaur(string? name, int age, string? species, float weight, int nbrLegs, Diet? diet)
    {
        _name = name;
        _age = age;
        _species = species;
        _weight = weight;
        _nbrLegs = nbrLegs;
        _diet = diet;
    }
    
    public void Display()
    {
        Console.WriteLine($"Dinosaur name: {_name}, aged {Age} years old, {Species}, and {Weight} kg");
    }
}
public enum Diet
{
    Herbivorous,
    Carnivorous
}