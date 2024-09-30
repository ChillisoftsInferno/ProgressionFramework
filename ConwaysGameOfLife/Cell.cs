using GlobalHelpers;

namespace ConwaysGameOfLife;

public class Cell
{
    private int[] _position;
    private int amountOfNeighbours;
    private CellState _state;

    public Cell(int[] position)
    {
        _position = position;
    }
    public int[] GetPosition() => _position;
    private int[] CreateCellPosition(int xPos, int yPos) => [xPos, yPos];
    public void SetAmountOfNeighbours(int neighbours) => amountOfNeighbours = neighbours;
    public int GetAmountOfNeighbours() => amountOfNeighbours;
    public void SetCellState(CellState state) => _state = state;
    public CellState GetCellState() => _state;
}
