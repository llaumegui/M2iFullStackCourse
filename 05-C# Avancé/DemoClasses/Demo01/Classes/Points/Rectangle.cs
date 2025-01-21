namespace Demo01.Classes.Points;

public class Rectangle : Figure
{
    private double _length;
    private double _width;

    public double Length => _length;
    public double Width => _width;

    public Rectangle(double length, double width)
    {
        _length = length;
        _width = width;
        Points = [new Point(-length, width), new Point(length, width),
            new Point(length, -width), new Point(-length, -width)];
    }
}