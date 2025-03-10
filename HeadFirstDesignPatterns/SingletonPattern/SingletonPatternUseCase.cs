// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.SingletonPattern;

public class SingletonPatternUseCase : IDesignPatternUseCase
{

    public static void Execute() 
    {
        // Get the Singleton instance
        Database db1 = Database.GetInstance();
        db1.Query("SELECT * FROM Users");

        // Try to create another instance
        Database db2 = Database.GetInstance();
        db2.Query("SELECT * FROM Orders");

        // Verify both instances are the same
        Console.WriteLine($"db1 and db2 are the same instance: {db1 == db2}");
    }
}
