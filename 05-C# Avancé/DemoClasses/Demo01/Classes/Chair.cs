namespace Demo01.Classes;

public class Chair
{
    private int _nbrLegs = 4;
    private string? _material = "bois";
    private string? _color = "blanc";

    public Chair() { }

    public Chair(int nbrLegs, string? material, string? color)
    {
        _nbrLegs = nbrLegs;
        _material = material;
        _color = color;
    }

    public override string ToString() =>
        $"Je suis une Chaise avec {_nbrLegs} pieds en {_material} et de couleur {_color}";
}