// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System;
using System.Threading;

namespace GlobalHelpers.Helpers;

public static class ConsoleHelper
{
    public static string NextLine(this string text)
    {
        text += "\n";
        return text;
    }
    
    public static string TwoLines(this string text)
    {
        text += "\n\n";
        return text;
    }
    
    public static void WriteOverTime(this string text, double secondsToGenerate = 1, double secondsToWaitForNext = 1)
    {
        int waitForNextTimer = Convert.ToInt32(secondsToWaitForNext * 1000) / 2;
        int timePerChar = Convert.ToInt32(secondsToGenerate * 1000 / text.Length);
        
        int counter = text.Length;
        int currentIndex = 0;
        while (currentIndex < counter)
        {
            Console.Write(text[currentIndex]);
            Thread.Sleep(timePerChar);
            currentIndex++;
        }
        Thread.Sleep(waitForNextTimer);
    }

    public static void WriteQuick(this string text)
    {
        text.WriteOverTime(0.1,0.1);
    }
    
    public static void WriteInstantly(this string text)
    {
        Console.Write(text);
    }
}
