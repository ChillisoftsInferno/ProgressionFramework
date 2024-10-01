namespace GameOfLife;

public class Map
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int OverallSize { get; set; }
    
    public Cell[,] Cells { get; set; }
    public List<Cell> CellsBorn { get; set; }
    public List<Cell> CellsDied { get; set; }
    
    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        OverallSize = Width * Height;
        Cells = new Cell[Width, Height];
        ResetCellsBorn();
        ResetCellsDied();
    }

    public List<Cell> ResetCellsBorn() => CellsBorn = new List<Cell>();
    public List<Cell> ResetCellsDied() => CellsDied = new List<Cell>();

    public void CellBorn(Cell cell) => CellsBorn.Add(cell);
    public void CellDied(Cell cell) => CellsDied.Add(cell);
}
