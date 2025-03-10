// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.DecoratorPattern;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }
    public override string GetDescription() 
        => _coffee.GetDescription() + ", Milk";
    public override double GetCost()
        => _coffee.GetCost() + 1.5;
}
