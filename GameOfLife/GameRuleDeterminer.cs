using GlobalHelpers;

namespace GameOfLife;

public class GameRuleDeterminer
{
    private Cell _cell;
    private int _amountOfNeighbours;
    private Map _map;

    public GameRuleDeterminer(NeighbourChecker checker, Cell cell, Map map)
    {
        _cell = cell;
        _map = map;
        _amountOfNeighbours = checker.GetAmountOfNeighbours(_cell);
    }
    
    public bool AliveCell_LessThanTwoNeighbours()
    {
        if (_amountOfNeighbours < 2)
        {
            _map.CellDied(_cell);
            return true;
        }
        return false;
    }
    
    public bool AliveCell_TwoOrThreeNeighbours()
    {
        if (_amountOfNeighbours == 2 || _amountOfNeighbours == 3)
        {
            return true;
        }
        return false;
    }

    public bool AliveCell_MoreThanThreeNeighbours()
    {
        if (_amountOfNeighbours > 3)
        {
            _map.CellDied(_cell);
            return true;
        }
        return false;
    }

    public void DeadCell_HasExactlyThreeNeighbours()
    {
        if (_amountOfNeighbours == 3)
        {
            _map.CellBorn(_cell);
        }
    }
}
