// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.Chapter1;

public abstract class Duck
{
    public string DuckName { get; set; } = nameof(Duck);
    
    public void Display()
    {
        Console.WriteLine($"I'm a duck. Infact I'm not just any duck... I'm a {DuckName}.");
    }
    public void Swim()
    {
        Console.WriteLine($"{DuckName} is swimming.");
    }
    public abstract void Quack();
    public abstract void Fly();
}
