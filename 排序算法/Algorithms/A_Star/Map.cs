namespace A_Star;

public struct Map
{
    private int map_width;                               //地图宽
    public int MAP_WIDTH
    {
        get { return map_width; }
    }
    
    private int map_height;                              //地图长
    public int MAP_HEIGHT
    {
        get { return map_height; }
    }

    public char[,] MapData { get; set; }                //地图数据
    public bool[,] ClosedPointPool {  get; set; }       //记录障碍物和关闭的点

    public Map(int mapWidth, int mapHeight)
    {
        map_width = mapWidth;
        map_height = mapHeight;
        MapData = new char[map_width, map_height];
        ClosedPointPool = new bool[map_width, map_height];
    }
}