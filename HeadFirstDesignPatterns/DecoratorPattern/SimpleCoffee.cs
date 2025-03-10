// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.DecoratorPattern;

public class SimpleCoffee : ICoffee
{

    public string GetDescription() => "Simple Coffee";
    public double GetCost() => 5.0;
}
