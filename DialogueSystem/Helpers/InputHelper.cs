// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DialogueSystem.Helpers;

public static class InputHelper
{
    public static string GetTextOutput()
    {
        string text = "";
        while (string.IsNullOrEmpty(text))
        {
            text = Console.ReadLine() ?? "";
        }
        return text;
    }

    public static int GetNumericOutput()
    {
        int numericResult = 0;
        bool isNumericValue = false;
        
        while(!isNumericValue)
        {
            string numToParse = GetTextOutput();
            isNumericValue = int.TryParse(numToParse, out numericResult);
        }
        return numericResult;
    }

    public static void WaitForEnterKey()
    {
        var key = Console.ReadKey(true);
        while (key.Key != ConsoleKey.Enter);
    }

    public static string GetConsoleKeyOutput()
    {
        var key = Console.ReadKey(true).Key;
        
        switch (key)
        {
            case ConsoleKey.D:
                break;
            case ConsoleKey.R:
                break;
            case ConsoleKey.L:
                break;
            case ConsoleKey.Q:
                break;
            default:
                return GetConsoleKeyOutput();
        }
        
        return key.ToString();
    }

    public static bool GetPredicateOutput()
    {
        return false;
    }

    public static bool GetYesNoOutput()
    {
        bool yesOrNoAnswer = false;
        bool validAnswer = false;
        
        while (!validAnswer)
        {
            var saveAnswer = Console.ReadKey(true).Key;
            if (saveAnswer is ConsoleKey.Y or ConsoleKey.N)
            {
                validAnswer = true;
                yesOrNoAnswer = saveAnswer == ConsoleKey.Y;
            }
            else "Invalid answer. Please enter one of the following symbols. [Y/N]".NextLine().WriteOverTime();
        }

        return yesOrNoAnswer;
    }
}
