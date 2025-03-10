// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.StrategyPattern;

public abstract class StrategyPatternUseCase : IDesignPatternUseCase
{
    public static void Execute()
    {
        PaymentContext context = new PaymentContext();

        // Use Credit Card payment
        context.SetPaymentStrategy(new CreditCardPayment());
        context.ProcessPayment(100.50m);

        // Use PayPal payment
        context.SetPaymentStrategy(new PayPalPayment());
        context.ProcessPayment(75.25m);

        // Use Bitcoin payment
        context.SetPaymentStrategy(new BitcoinPayment());
        context.ProcessPayment(200.00m);
    }
}
