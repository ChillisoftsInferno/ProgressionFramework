using GlobalHelpers;

namespace GameOfLife;

public class Cell
{
    public readonly Position Position;
    public CellState State { get; set; }

    public Cell(Position position, CellState state = CellState.Dead)
    {
        Position = position;
        if (state != CellState.Dead) State = state;
    }
}
