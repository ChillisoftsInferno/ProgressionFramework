namespace GameOfLife;

public class Position
{
    public int[] CellPosition { get; set; }

    public Position(int[] cellPos)
    {
        CellPosition = cellPos;
    }
}
