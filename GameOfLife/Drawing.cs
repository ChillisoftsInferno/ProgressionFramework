namespace GameOfLife;

public class Drawing
{
    public Map Map { get; set; }

    public string DrawMap()
    {
        for (int y = 0; y < Map.Height; y++)
        {
            for (int x = 0; x < Map.Height; x++)
            {
                Console.Write();
            }
        }
    }
}
