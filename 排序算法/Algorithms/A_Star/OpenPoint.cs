namespace A_Star;

public class OpenPoint
{
    public Point Pos { get; set; }
    public int Cost { get; set; }
    public int Prep { get; set; }

    public OpenPoint FatherPos { get; set; }
    
    public OpenPoint(Point pos, Point endPos, int cost, OpenPoint fatherPos)
    {
        Pos = pos;
        Cost = cost;
        FatherPos = fatherPos;
        int relativeX = Math.Abs(endPos.X - pos.X);
        int relativeY = Math.Abs(endPos.Y - pos.Y) ;

        int n = relativeY - relativeX;
        //预测值方案一：Prep = （max - n）* 14 + n * 10 + c
        Prep = Math.Max(relativeY, relativeX) * 14 - n * 4 + Cost;
        //预测值方案二：Prep = (relativeX + relativeY) * 10 + Cost;
        Prep = (relativeX + relativeY) * 10 + Cost;
        
    }

}