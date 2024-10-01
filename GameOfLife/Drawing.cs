namespace GameOfLife;

public class Drawing
{
    public Map Map { get; set; }

    public Drawing(Map map)
    {
        Map = map;
    }

    public void DrawMap()
    {
        for (int x = 0; x < Map.Width; x++)
        {
            for (int y = 0; y < Map.Height; y++)
            {
                Console.Write(Map.Cells[x, y].DrawCell());
            }
            Console.WriteLine();
        }
    }
}
