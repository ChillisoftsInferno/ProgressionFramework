using GlobalHelpers;

namespace GameOfLife;

public static class GameOfLifeProgram
{
    private static int s_mapWidth = 32;
    private static int s_mapHeight = 32;
    private static readonly Map s_map = new Map(s_mapWidth, s_mapHeight);

    private static Drawing s_drawing = null!;
    private static GameManager s_gameManager = null!;

    private static List<Position> s_startingPositions;
    private static NeighbourChecker s_checker;

    private static int generationCount = 0;

    private static readonly object s_lockObj = new object();
    private static bool s_isRunning = true;

    static GameOfLifeProgram()
    {
        InitializeGame();
        Console.CursorVisible = false;
    }

    private static void InitializeGame()
    {
        s_drawing = new Drawing(s_map);
        
        s_gameManager = new GameManager(s_map);
        s_gameManager.SetCellPositions();
        s_gameManager.SetStartingCells(SimulationConfigurations.SetStartingPositions(Configurations.SmallHeart));

        s_startingPositions = new List<Position>();

        s_checker = new NeighbourChecker(s_map);
    }
    
    public static void Main(string[] args)
    {
        // Start a separate thread to listen for key presses
        Thread inputThread = new Thread(CheckForPause);
        inputThread.IsBackground = true;
        inputThread.Start();
        
        while (true)
        {
            int populationCount = GetPopulationCount();

            lock (s_lockObj)
            {
                if (!s_isRunning)
                {
                    Console.WriteLine("[Q]uit\n" +
                                      "[D]ead Cells\n" +
                                      "[B]orn Cells\n" +
                                      "[C]ontinue\n");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Q:
                            return;
                        case ConsoleKey.D:
                            PrintCellsDied();
                            s_map.ResetCellsDied();
                            break;
                        case ConsoleKey.B:
                            PrintCellsBorn();
                            s_map.ResetCellsBorn();
                            break;
                        case ConsoleKey.C:
                            s_isRunning = true;
                            break;
                    }
                }

                generationCount++;
                Thread.Sleep(100);
                Console.Clear();
                s_drawing.DrawMap();
                UpdateMap();
            }
            
            Console.WriteLine($"Generation: {generationCount}");
            Console.WriteLine($"Population: {populationCount}");
            Console.WriteLine($"Press Spacebar to pause the game.");
            if(populationCount <= 0) break;
            
            s_map.ResetCellsBorn();
            s_map.ResetCellsDied();
        }
    }
    
    static void CheckForPause()
    {
        while (true)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                lock (s_lockObj)
                {
                    s_isRunning = !s_isRunning; // Toggle pause state
                    Console.WriteLine(s_isRunning ? "Resumed" : "Paused");
                }
            }
        }
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