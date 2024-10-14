// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DialogueSystem.Helpers;

public static class OutputHelper
{
    public static void RunLoadingIndicator(double secondsToWaitForNext = 2)
    {
        int timesLoaded = 0;
        int waitForNextTimer = Convert.ToInt32(secondsToWaitForNext * 1000 / 3);
        while (timesLoaded < 3)
        {
            ClearCurrentConsoleLine();
            Console.Write("Loading");
            "...".WriteOverTime(1,0);
            timesLoaded++;
        }
        Console.Clear();
    }
    
    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, currentLineCursor);
        Console.Write(new string(' ', Console.WindowWidth));  // Overwrite the current line with spaces
        Console.SetCursorPosition(0, currentLineCursor);     // Move the cursor back to the start of the line
    }
    
    public static void ClearPreviousConsoleLine()
    {
        int previousLineCursor = Console.CursorTop - 1;
        Console.SetCursorPosition(0, previousLineCursor);
        Console.Write(new string(' ', Console.WindowWidth));  // Overwrite the current line with spaces
        Console.SetCursorPosition(0, previousLineCursor);     // Move the cursor back to the start of the line
    }
}
