using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

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

    private List<OpenPoint> openPointPool = new List<OpenPoint>();
    private Dictionary<Point, int> openPointIndexInPool = new Dictionary<Point, int>();
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
        
        return Find(out path);
        
    }

    /// <summary>
    /// 检查点是否障碍物、或者已关闭
    /// </summary>
    public bool CheckPointIsClose(Point point)
    {
        if (point.X < 0 || point.Y < 0 || point.X >= map.MAP_WIDTH || point.Y >= map.MAP_HEIGHT)
            return true;

        return map.ClosedPointPool[point.Y, point.X];
    }

    public bool Find(out Queue<Point> path)
    {
        path = null;
        OpenPoint curPoint;
        openPointPool.Add(new OpenPoint(this.startPos, this.endPos, 0, null));
        //List<OpenPoint> pointQueue = new List<OpenPoint>();
        
        while (openPointPool.Count > 0)
        {
            curPoint = openPointPool[openPointPool.Count - 1];
            openPointPool.RemoveAt(openPointPool.Count - 1);
            map.ClosedPointPool[curPoint.Pos.Y, curPoint.Pos.X] = true;
            openPointIndexInPool.Remove(curPoint.Pos);
            
            for (int i = 0; i < 8; i++)
            {
                Point nextDir = new Point(curPoint.Pos.X + direction[i, 0], curPoint.Pos.Y + direction[i, 1]);

                if (CheckPointIsClose(nextDir))
                    continue;
                
                if (!CheckIsSatisfyRule(curPoint.Pos, i))
                    continue;
                
                if (nextDir.Equals(endPos))
                {
                    path = GetPath(curPoint);
                    return true;
                }
                
                int index = -1;
                int cost = curPoint.Cost + costs[i];
                OpenPoint nextDirPoint = new OpenPoint(nextDir, endPos, cost, curPoint);
                
                if (openPointIndexInPool.TryGetValue(nextDir, out index))
                {
                    if (nextDirPoint.Prep <= openPointPool[index].Prep)
                    {
                        openPointPool.RemoveAt(index);
                        openPointIndexInPool.Remove(nextDir);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (openPointPool.Count > 0)
                {
                    int j = 0;
                    for (; j < openPointPool.Count; j++)
                    {
                        if (nextDirPoint.Prep > openPointPool[j].Prep)
                        {
                            break;
                        }
                    }
                    openPointPool.Insert(j, nextDirPoint);

                }
                else
                {
                    openPointPool.Add(nextDirPoint);
                }
                
                /*if (pointQueue.Count > 0)
                {
                    int j = 0;
                    for (; j < pointQueue.Count; j++)
                    {
                        if (nextDirPoint.Prep > pointQueue[j].Prep)
                        {
                            break;
                        }
                    }
                    pointQueue.Insert(j, nextDirPoint);
                }
                else
                {
                    pointQueue.Add(nextDirPoint);
                }*/
                
            }
            
            /*foreach (var p in pointQueue)
            {   
                openPointPool.Add(p); 
                openPointIndexInPool.Add(p.Pos, openPointPool.Count - 1);
            }
            
            pointQueue.Clear();*/

        }
        
        return false;
    }

    /// <summary>
    /// 判断当前搜索方向是否满足搜索规则
    /// </summary>
    public bool CheckIsSatisfyRule(Point start, int dirIndex)
    {
        if (Math.Abs(direction[dirIndex, 0]) == 1 && Math.Abs(direction[dirIndex, 1]) == 1)
        {
            if (CheckPointIsClose(new Point(start.X + direction[dirIndex, 0], start.Y)))
                return false;
            if (CheckPointIsClose(new Point(start.X, start.Y + direction[dirIndex, 1])))
                return false;
        }
        return true;
    }

    public Queue<Point> GetPath(OpenPoint point)
    {
        Queue<Point> path = new Queue<Point>();
        while (point != null)
        {
            path.Enqueue(point.Pos);
            point = point.FatherPos;
        }

        return path;
    }

    private bool EnqueueCamparer(OpenPoint a, OpenPoint b)
    {
        if (a == null || b == null)
        {
            return false;
        }
        if (a.Prep >= b.Prep)
            return true;
        else
            return false;
    }

    private bool GetItemCamparer(OpenPoint a, OpenPoint b)
    {
        if (a == null || b == null)
        {
            return false;
        }
        if (a.Pos.Equals(b.Pos))
            return true;
        else
            return false;
    }

}