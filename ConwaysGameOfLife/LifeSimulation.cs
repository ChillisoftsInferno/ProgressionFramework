using System.ComponentModel.DataAnnotations;

namespace ConwaysGameOfLife;

public static class LifeSimulation
{
    public static void Main(string[] args)
    {
        CellLifeHelper.LifeMap = new Map(10, 10);
        CellLifeHelper.LifeMap.RandomizeCellPositions(10);
        RunSimulation();
    }

    private static void GenerateGrid()
    {
        if (CellLifeHelper.LifeMap == null) throw new ArgumentNullException(nameof(CellLifeHelper.LifeMap));
        
        for (int y = 0; y < CellLifeHelper.LifeMap.GetMapSize()[0]; y++)
        {
            int x;
            for (x = 0; x < CellLifeHelper.LifeMap.GetMapSize()[1] - 1; x++)
            {
                if (CellLifeHelper.LifeMap.GetAllCells().Any(c => c.GetPosition()[0] == y && c.GetPosition()[1] == x))
                {
                    Console.Write(" X ");
                    continue;
                }
                Console.Write(" _ ");
            }
            if (CellLifeHelper.LifeMap.GetAllCells().Any(c => c.GetPosition()[0] == y && c.GetPosition()[1] == x))
            {
                Console.Write(" X ");
                continue;
            }
            Console.WriteLine(" _ ");
        }
    }

    private static void RunSimulation()
    {
        if (CellLifeHelper.LifeMap == null) throw new ArgumentNullException(nameof(CellLifeHelper.LifeMap));
        
        GenerateGrid();
        Console.WriteLine("Game initialized");
        
        var cells = CellLifeHelper.LifeMap.GetAllCells();
        var count = 0;
        foreach (var cell in cells)
        {
            if (cell.Survives())
            {
                count++;
                Console.WriteLine
                (
                    $"Cell [{count}]\n" +
                    $"Pos: [{cell.GetPosition()[0]}:{cell.GetPosition()[1]}] survived!\n" +
                    $"Neighbours: [{cell.GetAmountOfNeighbours()}]"
                );
            }
            else
            {
                count++;
                Console.WriteLine
                (
                    $"Cell [{count}]\n" +
                    $"Pos: [{cell.GetPosition()[0]}:{cell.GetPosition()[1]}] died...!\n" +
                    $"Neighbours: [{cell.GetAmountOfNeighbours()}]"
                );
            }
        }
    }
}