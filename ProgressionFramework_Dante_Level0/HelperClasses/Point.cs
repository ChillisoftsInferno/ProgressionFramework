namespace ProgressionFramework_Dante_Level0.HelperClasses;

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public void Move(int deltaX, int deltaY)
    {
        X += deltaX;
        Y += deltaY;
    }
}
