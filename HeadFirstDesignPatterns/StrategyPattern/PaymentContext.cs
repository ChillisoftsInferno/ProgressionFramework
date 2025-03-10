// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.StrategyPattern;

public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            throw new InvalidOperationException("PaymentStrategy is not set");
        }
        _paymentStrategy.Pay(amount);
    }
}
