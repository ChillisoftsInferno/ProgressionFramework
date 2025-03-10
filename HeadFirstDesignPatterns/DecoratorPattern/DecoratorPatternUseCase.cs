// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.DecoratorPattern;

public class DecoratorPatternUseCase : IDesignPatternUseCase
{

    public static void Execute()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

        // Coffee with Milk
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

        // Coffee with Milk and Sugar
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
    }
}
