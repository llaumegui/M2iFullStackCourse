namespace Demo01.Classes.Points;

public abstract class Figure : IMovable
{
    public Point Origin { get; private set; } = new Point(0, 0);
    protected Point[] Points { get; set; } = [];
    
    public void Move(double newX, double newY)
    {
        foreach (Point point in Points)
        {
            point.X -= Origin.X;
            point.X += newX;
            point.Y -= Origin.Y;
            point.Y += newY;
        }
        Origin.X += newX;
        Origin.Y += newY;
    }

    public override string ToString()
    {
        string msg = "";
        for(int i = 0; i < Points.Length; i++)
            msg += $"{(char)(65+i)} = {Points[i].ToString()}{(i>=Points.Length-1?"":"\n")}";
        return msg;
    }
}