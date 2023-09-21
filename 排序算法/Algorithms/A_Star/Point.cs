namespace A_Star;

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point()
    {
        X = -1;
        Y = -1;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}