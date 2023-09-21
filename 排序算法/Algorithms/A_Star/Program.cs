// See https://aka.ms/new-console-template for more information

using A_Star;

public class Program
{
    static Map map;
    static AStar aStar;
    static Queue<Point>? path;
    
    public static int Main()
    {
        map = new Map(40, 70);
        aStar = new AStar(map);
        CreateMap();
        PrintMap();
        int dulTime = 0;
        while (dulTime < 2000)
        {
            dulTime++;
        }

        aStar.Start(new Point(20, 30), new Point( 70, 50), out path);

        while (path != null && path.Count > 0)
        {
            Point point = path.Dequeue();
            map.MapData[point.X, point.Y] = 'O';
        }

        PrintMap();
        return 1;
    }

    public static void CreateMap()
    {
        Random random = new Random();
        for (int i = 0; i < map.MAP_WIDTH; ++i)
        for (int j = 0; j < map.MAP_HEIGHT; ++j) {
            // 五分之一概率生成障碍物，不可走
            if (random.Next() % 5 == 0) {
                map.MapData[i,j] = '*';
                map.ClosedPointPool[i,j] = true;
            }
            else {
                map.MapData[i,j] = ' ';
                map.ClosedPointPool[i,j] = false;
            }
        }
    }
    
    static void  PrintMap() {
        Console.WriteLine("---------------------------------------------------------------------------------");

        for (int i = 0; i < map.MAP_WIDTH; ++i) {
            for (int j = 0; j < map.MAP_HEIGHT; ++j)
                Console.Write(map.MapData[i,j]);
            Console.Write('\n');
        }
        Console.WriteLine("---------------------------------------------------------------------------------");
    }

}







