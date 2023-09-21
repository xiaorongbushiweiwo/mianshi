using System.Collections.Generic;
using System.Diagnostics;

namespace A_Star;

public class AStar
{
    private Map map;
    private Point startPos = new Point();
    private Point endPos = new Point();
    
    private int depth = 0;                                          //记录深度
    private readonly int depthLimit;                            //深度限制

    private readonly int[,] direction = new int[,]
    {
        { 1, 0},
        { 1, 1},
        { 0, 1},
        {-1, 1},
        {-1, 0},
        {-1,-1},
        { 0,-1},
        { 1,-1}
    };

    private readonly int[] costs = { 10, 14, 10, 14, 10, 14, 10, 14 };
    
    PriorityQueue<OpenPoint, int> openPointPool = new PriorityQueue<OpenPoint, int>();

    public AStar(Map map)
    {
        this.map = map;
        depthLimit = map.MAP_WIDTH * map.MAP_HEIGHT / 2;
    }

    public bool Start(Point startPos, Point endPos, out Queue<Point> path)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        path = null;

        if (CheckPointIsClose(startPos))
            return false;
        
        path = Find(startPos);
        
        return false;
    }

    /// <summary>
    /// 检查点是否障碍物、或者已关闭
    /// </summary>
    public bool CheckPointIsClose(Point point)
    {
        if (point.X < 0 || point.Y < 0 || point.X >= map.MAP_WIDTH || point.Y >= map.MAP_HEIGHT)
            return true;

        return map.ClosedPointPool[point.X, point.Y];
    }

    public Queue<Point> Find(Point point)
    {
        if (CheckPointIsClose(point))
            return null;
        
        //起始点
        OpenPoint openPoint = new OpenPoint(startPos, endPos, 0, null);
        openPointPool.Enqueue(openPoint, 0);
        bool isFind = false;
        OpenPoint curPoint = null;
        Point curPos = new Point();
        while (openPointPool.Count > 0)
        {
            /*depth++;
            if (depth > depthLimit)
                return null;*/
            
            curPoint = openPointPool.Dequeue();
            curPos = curPoint.Pos;
            map.ClosedPointPool[curPos.X, curPos.Y] = true;
            for (int i = 0; i < 8; i++)
            {
                Point nextPoint = new Point(curPos.X + direction[i, 0], curPos.Y + direction[i, 1]);
                if (CheckPointIsClose(nextPoint))
                    continue;
                if (nextPoint.Equals(endPos))
                {
                    isFind = true;
                }
                int curCost = curPoint.Cost + costs[i];
                openPointPool.Enqueue(new OpenPoint(nextPoint, endPos, curCost, curPoint), curCost);
            }
        }
        
        Queue<Point> path = new Queue<Point>();

        if (isFind)
        {
            while (curPoint.Equals(null) && !CheckPointIsClose(curPoint.Pos))
            {
                path.Enqueue(curPoint.Pos);
                curPoint = curPoint.FatherPos;
            }

            return path;
        }
        else
        {
            return null;
        }

    }
}