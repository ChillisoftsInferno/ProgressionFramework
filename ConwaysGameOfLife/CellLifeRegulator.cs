namespace ConwaysGameOfLife;

public static class CellLifeRegulator
{
    public static bool CanRepopulate;
    public static Map? LifeMap;
    public static Neighbourhood? Neighbourhood;
    
    public static bool Survives(this Cell cell)
    {
        LifeMap = CellLifeHelper.LifeMap ?? null;
        if (LifeMap == null) throw new ArgumentNullException(nameof(LifeMap));
        Neighbourhood = new Neighbourhood(LifeMap);
        if (Neighbourhood == null) throw new ArgumentNullException(nameof(Neighbourhood));
        
        cell.SetAmountOfNeighbours(Neighbourhood.CheckCellNeighbours(cell));
        if (cell.HasLessThanTwoLiveNeighbours()) return false;
        if (cell.HasTwoOrThreeLiveNeighbours())
        {
            CanRepopulate = cell.HasExactlyThreeNeighbours();
            return true;
        }
        if (cell.HasMoreThanThreeLiveNeighbours()) return false;
        return false;
    }
}

public static class CellLifeHelper
{
    public static Map? LifeMap;
    
    public static bool HasLessThanTwoLiveNeighbours(this Cell cell)
    {
        IsLifeMapNull();
        if (cell.GetAmountOfNeighbours() < 2) return true;
        return false;
    }

    public static bool HasTwoOrThreeLiveNeighbours(this Cell cell)
    {
        IsLifeMapNull();
        if (cell.GetAmountOfNeighbours() == 2 || cell.GetAmountOfNeighbours() == 3) return true;
        return false;
    }

    public static bool HasMoreThanThreeLiveNeighbours(this Cell cell)
    {
        IsLifeMapNull();
        if (cell.GetAmountOfNeighbours() > 3) return true;
        return false;
    }

    public static bool HasExactlyThreeNeighbours(this Cell cell)
    {
        IsLifeMapNull();
        if (cell.GetAmountOfNeighbours() == 3) return true;
        return false;
    }
    
    public static int[] RandomizeCellPosition()
    {
        IsLifeMapNull();
        Random r = new Random();
        var xPos = r.Next(0, LifeMap.GetMapSize()[0] + 1);
        var yPos = r.Next(0, LifeMap.GetMapSize()[1] + 1);
        return new int[] { xPos, yPos };
    }

    private static void IsLifeMapNull()
    {
        if (LifeMap == null) throw new ArgumentNullException(nameof(LifeMap));
    }
}
