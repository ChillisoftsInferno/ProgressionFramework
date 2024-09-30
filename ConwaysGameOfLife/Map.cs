namespace ConwaysGameOfLife;

public class Map
{
    private int _width;
    private int _height;
    private List<int[]> _cellPositions;
    private List<Cell> _cells = new List<Cell>();
    
    public Map (int width, int height)
    {
        _width = width;
        _height = height;
    }
    
    public Map (int width, int height, List<int[]> cellPositions)
    {
        _width = width;
        _height = height;
        _cellPositions = cellPositions;
    }

    public int[] GetMapSize()
    {
        return new[] { _width, _height };
    }

    public void RandomizeCellPositions(int amountOfCells)
    {
        _cellPositions = GetRandomCellPositions(amountOfCells);
    }

    public List<int[]> GetRandomCellPositions(int amountOfCellsToGenerate)
    {
        var count = 0;
        AddCellToMap(new Cell([5,4]));
        AddCellToMap(new Cell([5,5]));
        AddCellToMap(new Cell([5,6]));
        while (count < amountOfCellsToGenerate)
        {
            var cell = new Cell(CellLifeHelper.RandomizeCellPosition());
            if (_cells.Any(c => c.GetPosition() == cell.GetPosition())) continue;
            AddCellToMap(cell);
            count++;
        }

        return SetRandomCellPositions(amountOfCellsToGenerate);
    }

    private List<int[]> SetRandomCellPositions(int amountOfCellsToGenerate)
    {
        List<int[]> cellPositions = new List<int[]>();
        for (int i = 0; i < amountOfCellsToGenerate; i++)
        {
            cellPositions.Add(_cells[i].GetPosition());
        }
        return cellPositions;
    }

    private void AddCellToMap(Cell cell) => _cells.Add(cell);

    public List<Cell> GetAllCells() => _cells;
}
