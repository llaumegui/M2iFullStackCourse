namespace Demo01.Classes.Points;

public class Point
{
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;

    public Point(double x = 0, double y = 0)
    {
        X = x;
        Y = y;
    }
    
    public override string ToString() => $"({X};{Y})";
}