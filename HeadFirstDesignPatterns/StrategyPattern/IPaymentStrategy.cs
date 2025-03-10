// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.StrategyPattern;

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}
