// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.FactoryPattern;

public class ShapeFactory
{
    public static IShape CreateShape(string shapeType)
    {
        return shapeType.ToLower() switch
        {
            "circle" => new Circle(),
            "rectangle" => new Rectangle(),
            "triangle" => new Triangle(),
            _ => throw new ArgumentException("Invalid shape type"),
        };
    }
}
