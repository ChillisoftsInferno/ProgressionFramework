// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.SingletonPattern;

public class Database
{
    private static Database? s_instance;

    private Database()
    {
        Console.WriteLine("Database Connection Initialized.");
    }

    public static Database GetInstance()
    {
        return s_instance ??= new Database();
    }

    public void Query(string sql)
    {
        Console.WriteLine($"Executing Query: {sql}");
    }
}
