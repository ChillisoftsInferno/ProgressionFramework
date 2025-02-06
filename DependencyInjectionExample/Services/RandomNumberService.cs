// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DependencyInjectionExample.Services;

public class RandomNumberService
{
    private readonly int _randomNumber;

    public RandomNumberService()
    {
        var random = new Random();
        _randomNumber = random.Next(0, 101);
    }

    public int GetNumber() => _randomNumber;
}
