using GlobalHelpers;

namespace GameOfLife;

public class Cell
{
    public Position Position { get; set; }
    public CellState State { get; set; }

    public Cell(Position position, CellState state = CellState.Dead)
    {
        Position = position;
        State = state;
    }

    public string DrawCell()
    {
        if (State == CellState.Alive)
        {
            return " A ";
        }
        return "   ";
    }
}
