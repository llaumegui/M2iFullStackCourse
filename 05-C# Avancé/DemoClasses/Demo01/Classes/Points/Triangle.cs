namespace Demo01.Classes.Points;

public class Triangle : Figure
{
    private double _base;
    private double _height;
    
    public double Base => _base;
    public double Height => _height;

    public Triangle(double baseT, double height)
    {
        _base = baseT;
        _height = height;
        Points = [new Point(0, height), new Point((baseT / 2), 0), new Point(-(baseT / 2), 0)];
    }
}