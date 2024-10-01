namespace GameOfLife;

public static class DeterminedPositions
{
    public static int[,] TopPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0] - 1, pos[0, 1] } };
        if (newPos[0, 0] < 0) newPos[0, 0] = 0;
        return newPos;
    }
    
    public static int[,] BottomPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0] + 1, pos[0, 1] } };
        if (newPos[0, 0] > map.Height - 1) newPos[0, 0] = map.Height - 1;
        return newPos;
    }
    
    public static int[,] LeftPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0], pos[0, 1] - 1 } };
        if (newPos[0, 1] < 0) newPos[0, 1] = 0;
        return newPos;
    }
    
    public static int[,] RightPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0], pos[0, 1] + 1 } };
        if (newPos[0, 1] > map.Width - 1) newPos[0, 1] = map.Width - 1;
        return newPos;
    }
    
    public static int[,] TopLeftPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0], pos[0, 1] } };
        return newPos.TopPos(map).LeftPos(map);
    }
    
    public static int[,] TopRightPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0], pos[0, 1] } };
        return newPos.TopPos(map).RightPos(map);
    }
    
    public static int[,] BottomLeftPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0], pos[0, 1] } };
        return newPos.BottomPos(map).LeftPos(map);
    }
    
    public static int[,] BottomRightPos(this int[,] pos, Map map)
    {
        int[,] newPos = { { pos[0, 0], pos[0, 1] } };
        return newPos.BottomPos(map).RightPos(map);
    }
}
