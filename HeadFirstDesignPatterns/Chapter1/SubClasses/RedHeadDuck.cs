// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.Chapter1.SubClasses;

public class RedHeadDuck : Duck
{
    public override void Quack() => throw new NotImplementedException();
    public override void Fly() => throw new NotImplementedException();
}
