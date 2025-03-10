// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.StrategyPattern;

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using credit card.");
    }
}