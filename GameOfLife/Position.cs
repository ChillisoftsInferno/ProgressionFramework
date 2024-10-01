namespace GameOfLife;

public class Position
{
    public int[,] CellPosition { get; set; }

    public Position(int xPos, int yPos)
    {
        CellPosition = new [,] { {xPos, yPos} };
    }

    public bool Equals(int[,] pos)
    {
        if (CellPosition[0, 0] == pos[0, 0] && CellPosition[0, 1] == pos[0, 1]) return true;
        return false;
    }

    public override string ToString()
    {
        return $"Cell Pos: [{CellPosition[0, 0]}, {CellPosition[0, 1]}]";
    }
}
