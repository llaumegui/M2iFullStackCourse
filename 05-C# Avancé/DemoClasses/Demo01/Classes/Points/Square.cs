namespace Demo01.Classes.Points;

public class Square : Figure
{
    private double _side;
    public double Side => _side;

    public Square(double side)
    {
        _side = side;
        Points = [new Point(-side, side), new Point(side, side), new Point(side, -side), new Point(-side, -side)];
    }

}