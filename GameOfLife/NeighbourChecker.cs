using GlobalHelpers;

namespace GameOfLife;

public class NeighbourChecker
{
    public Map Map { get; set; }

    public NeighbourChecker(Map map)
    {
        Map = map;
    }

    public int GetAmountOfNeighbours(Cell cell)
    {
        int count = 0;
        
        if (HasTopNeighbour(cell)) count++;
        if (HasBottomNeighbour(cell)) count++;
        if (HasLeftNeighbour(cell)) count++;
        if (HasRightNeighbour(cell)) count++;
        if (HasTopLeftNeighbour(cell)) count++;
        if (HasTopRightNeighbour(cell)) count++;
        if (HasBottomLeftNeighbour(cell)) count++;
        if (HasBottomRightNeighbour(cell)) count++;
        
        return count;
    }

    private bool HasTopNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.TopPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasBottomNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.BottomPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasLeftNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.LeftPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasRightNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.RightPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasTopLeftNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.TopLeftPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasTopRightNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.TopRightPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasBottomLeftNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.BottomLeftPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
    
    private bool HasBottomRightNeighbour(Cell cell)
    {
        int[,] pos = cell.Position.CellPosition.BottomRightPos(Map);
        return Map.Cells[pos[0, 0], pos[0, 1]].State == CellState.Alive;
    }
}
