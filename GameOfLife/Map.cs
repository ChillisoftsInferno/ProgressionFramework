namespace GameOfLife;

public class Map
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int OverallSize { get; set; }
    
    public Cell[,] Cells { get; set; }
    
    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        OverallSize = Width * Height;
    }    
}
