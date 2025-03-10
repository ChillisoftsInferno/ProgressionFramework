// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using HeadFirstDesignPatterns.DecoratorPattern;
using HeadFirstDesignPatterns.FactoryPattern;
using HeadFirstDesignPatterns.ObserverPattern;
using HeadFirstDesignPatterns.StrategyPattern;

namespace HeadFirstDesignPatterns;

public static class Program
{
    private static DesignPatternEnum s_selectedPattern;
    
    public static void Main()
    {
        Console.WriteLine("Select Pattern Example");
        SelectPatternExample();
    }

    private static void SelectPatternExample()
    {
        string? input = Console.ReadLine();
        
        while (!IsValidDesignPattern(input)) SelectPatternExample();
        
        RunDesignPatternExample();
    }

    private static bool IsValidDesignPattern(string? input)
    {
        if (input == null) return false;
        if (Enum.TryParse(input, true, out DesignPatternEnum designPattern))
        {
            s_selectedPattern = designPattern;
            return designPattern switch
            {
                DesignPatternEnum.Strategy => true,
                _ => false
            };
        }
        
        Console.WriteLine("Invalid design pattern. Please try again.");
        return false;
    }

    private static void RunDesignPatternExample()
    {
        switch (s_selectedPattern)
        {
            case DesignPatternEnum.Strategy:
                StrategyPatternUseCase.Execute();
                break;
            case DesignPatternEnum.Observer:
                ObserverPatternUseCase.Execute();
                break;
            case DesignPatternEnum.Decorator:
                DecoratorPatternUseCase.Execute();
                break;
            case DesignPatternEnum.Factory:
                FactoryDesignPatternUseCase.Execute();
                break;
            case DesignPatternEnum.Singleton:
            default:
                throw new ArgumentOutOfRangeException(nameof(s_selectedPattern),
                    $"No valid design pattern has been assigned to {s_selectedPattern}.");
        }
    }
}
