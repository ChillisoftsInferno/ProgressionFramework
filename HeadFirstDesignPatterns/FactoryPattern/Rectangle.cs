// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.FactoryPattern;

public class Rectangle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Rectangle.");
}
