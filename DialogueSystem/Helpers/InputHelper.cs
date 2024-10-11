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

    public static bool GetConsoleKeyOutput()
    {
        return false;
    }

    public static bool GetPredicateOutput()
    {
        return false;
    }
}
