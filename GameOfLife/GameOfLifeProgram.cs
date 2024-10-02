using GlobalHelpers;

namespace GameOfLife;

public static class GameOfLifeProgram
{
    private static int s_mapWidth = 15;
    private static int s_mapHeight = 15;
    private static readonly Map s_map = new Map(s_mapWidth, s_mapHeight);

    private static Drawing s_drawing = null!;
    private static GameManager s_gameManager = null!;

    private static List<Position> s_startingPositions;
    private static NeighbourChecker s_checker;

    private static int generationCount = 0;

    static GameOfLifeProgram()
    {
        InitializeGame();
    }

    private static void InitializeGame()
    {
        s_drawing = new Drawing(s_map);
        
        s_gameManager = new GameManager(s_map);
        s_gameManager.SetCellPositions();
        s_gameManager.SetStartingCells(SetSecondStartingPositions());

        s_startingPositions = new List<Position>();

        s_checker = new NeighbourChecker(s_map);
    }
    
    public static void Main(string[] args)
    {
        while (true)
        {
            generationCount++;
            int populationCount = GetPopulationCount();
            Thread.Sleep(100);
            Console.Clear();
            s_drawing.DrawMap();
            UpdateMap();
            
            //Console.WriteLine("Press Q to Quit. Press any key to skip to next generation.");
            // switch (Console.ReadKey(true).Key)
            // {
            //     case ConsoleKey.Q:
            //         return;
            //     case ConsoleKey.D:
            //         PrintCellsDied();
            //         s_map.ResetCellsDied();
            //         break;
            //     case ConsoleKey.B:
            //         PrintCellsBorn();
            //         s_map.ResetCellsBorn();
            //         break;
            // }
            
            Console.WriteLine($"Generation: {generationCount}");
            Console.WriteLine($"Population: {populationCount}");
            if(populationCount <= 0) break;
            
            s_map.ResetCellsBorn();
            s_map.ResetCellsDied();
        }
    }

    private static List<Position> SetStartingPositions()
    {
        return new List<Position>()
        {
            new (3,3),
            new (3,4),
            new (3,5),
            new (3,6),
            new (3,7),
            new (3,8),
            new (4,3),
            new (4,4),
            new (4,5),
            new (4,6),
            new (4,7),
            new (4,8),
            
            new (3,10),
            new (3,11),
            new (4,10),
            new (4,11),
            new (5,10),
            new (5,11),
            new (6,10),
            new (6,11),
            new (7,10),
            new (7,11),
            new (8,10),
            new (8,11),
            
            new (10,6),
            new (10,7),
            new (10,8),
            new (10,9),
            new (10,10),
            new (10,11),
            new (11,6),
            new (11,7),
            new (11,8),
            new (11,9),
            new (11,10),
            new (11,11),
            
            new (6,3),
            new (6,4),
            new (7,3),
            new (7,4),
            new (8,3),
            new (8,4),
            new (9,3),
            new (9,4),
            new (10,3),
            new (10,4),
            new (11,3),
            new (11,4),
        };
    }

    private static List<Position> SetSecondStartingPositions()
    {
        return new List<Position>()
        {
            new (6,6),
            new (7,6),
            new (7,7),
            new (7,8),
            new (8,7),
            new (6,8),
        };
    }
    
    private static void UpdateMap()
    {
        foreach (var cell in s_map.Cells)
        {
            GameRuleDeterminer determiner = new GameRuleDeterminer(s_checker, cell, s_map);
            
            switch (cell.State)
            {
                case CellState.Alive:
                    if(determiner.AliveCell_LessThanTwoNeighbours()) break;
                    if (determiner.AliveCell_TwoOrThreeNeighbours()) break;
                    if (determiner.AliveCell_MoreThanThreeNeighbours()) break;
                    break;
                default:
                    determiner.DeadCell_HasExactlyThreeNeighbours();
                    break;
            }
        }

        foreach (var cell in s_map.Cells)
        {
            if (s_map.CellsDied.Contains(cell)) cell.State = CellState.Dead;
            if (s_map.CellsBorn.Contains(cell)) cell.State = CellState.Alive;
        }
    }

    private static int GetPopulationCount()
    {
        int populationCount = 0;
        foreach (var cell in s_map.Cells)
        {
            if (cell.State == CellState.Alive)
            {
                populationCount++;
            }
        }

        return populationCount;
    }

    private static void PrintCellsBorn()
    {
        Console.WriteLine("Cells that were born...");
        foreach (var cell in s_map.CellsBorn)
        {
            Console.WriteLine($"{cell.Position}");
        }
    }
    
    private static void PrintCellsDied()
    {
        Console.WriteLine("Cells that died...");
        foreach (var cell in s_map.CellsDied)
        {
            Console.WriteLine($"{cell.Position}");
        }
    }
}