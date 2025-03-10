// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.FactoryPattern;

public class FactoryDesignPatternUseCase : IDesignPatternUseCase
{

    public static void Execute()
    {
        IShape shape1 = ShapeFactory.CreateShape("Circle");
        shape1.Draw(); //Output: Drawing a Circle
        
        IShape shape2 = ShapeFactory.CreateShape("Rectangle");
        shape2.Draw(); //Output: Drawing a Rectangle
        
        IShape shape3 = ShapeFactory.CreateShape("Triangle");
        shape3.Draw(); //Output: Drawing a Triangle
        
        IShape shape4 = ShapeFactory.CreateShape("Square");
        shape4.Draw(); //Output: Invalid shape
    }
}
