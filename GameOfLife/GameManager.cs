using GlobalHelpers;

namespace GameOfLife;

public class GameManager
{
    public Map Map { get; set; }

    public GameManager(Map map)
    {
        Map = map;
    }
    
    public void SetCellPositions()
    {
        for (int y = 0; y < Map.Height; y++)
        {
            for (int x = 0; x < Map.Width; x++)
            {
                Map.Cells[x, y] = new Cell(new Position(x, y), CellState.Dead);
            }
        }
    }

    public void SetStartingCells(List<Position> cellPositions)
    {
        foreach (var cell in Map.Cells)
        {
            foreach (var pos in cellPositions)
            {
                if (cell.Position.Equals(pos.CellPosition))
                {
                    cell.State = CellState.Alive;
                    break;
                }
            }
        }
    }

    
}
