// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace ProgressionFramework_Dante_Level0.FunSideActivities.Hashing;

public static class CustomConsole
{
    public static string Ensure()
    {
        string? value = Console.ReadLine();
        while (string.IsNullOrEmpty(value))
        {
            value = Console.ReadLine();
        }
        return value;
    }
}
