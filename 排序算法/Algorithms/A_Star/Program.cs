// See https://aka.ms/new-console-template for more information

using A_Star;

public class Program
{
    static Map map = new Map(7, 7);
    static AStar aStar;
    static Point startPos = new Point(1, 1);
    static Point endPos = new Point(6, 6);
    static Queue<Point>? path;
    
    public static int Main()
    {
        aStar = new AStar(map);

        CreateMap();
        PrintMap();

        bool isFinded = aStar.Start(startPos, endPos, out path);
        if (isFinded)
            Console.WriteLine("Find successed!");
        else
            Console.WriteLine("Find fail!");

        if (path != null)
        {
            Point point = new Point();
            while (path.Count > 1)
            {
                point = path.Dequeue();
                map.MapData[point.Y, point.X] = 'O';
            }
            point = path.Dequeue();
            map.MapData[point.Y, point.X] = 'S';
        }


        PrintMap();
        return 1;
    }

    public static void CreateMap()
    {
        Random random = new Random();
        for (int i = 0; i < map.MAP_HEIGHT; ++i)
        for (int j = 0; j < map.MAP_WIDTH; ++j) {

            /*if (j == 3 && (i == 2 || i == 3 || i == 4))
            {
                map.MapData[i,j] = '*';
                map.ClosedPointPool[i,j] = true;
            }
            else
            {
                map.MapData[i,j] = ' ';
                map.ClosedPointPool[i,j] = false;
            }*/
            
            // 五分之一概率生成障碍物，不可走
            if (random.Next() % 4 == 0 && (endPos.X != i && endPos.Y != j)) {
                map.MapData[i,j] = '*';
                map.ClosedPointPool[i,j] = true;
            }
            else {
                map.MapData[i,j] = ' ';
                map.ClosedPointPool[i,j] = false;
            }
        }
        PrintMap();
        map.MapData[startPos.X, startPos.Y] = 'S';
        map.MapData[endPos.X, endPos.Y] = 'E';
    }
    
    static void  PrintMap() {
        Console.WriteLine("---------------------------------------------------------------------------------");

        for (int i = 0; i <= map.MAP_HEIGHT; ++i) {
            for (int j = 0; j <= map.MAP_WIDTH; ++j)
            {
                if (i == 0)
                {
                    int lie = (j - 1) < 0 ? 0 : j - 1;
                    Console.Write(lie + "  ");
                    continue;
                }
                if (j == 0)
                {
                    int hang = (i - 1) < 0 ? 0 : i - 1;
                    Console.Write(hang + "  ");
                    continue;
                }
                
                Console.Write(map.MapData[i - 1,j - 1] + "  ");

            }

            Console.Write('\n');
        }
        Console.WriteLine("---------------------------------------------------------------------------------");
    }

}







