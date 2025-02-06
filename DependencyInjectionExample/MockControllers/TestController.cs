// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DependencyInjectionExample.Services;
using NUnit.Framework;

namespace DependencyInjectionExample.MockControllers;

[TestFixture]
public class TestController
{
    private readonly RandomNumberService _randomNumberService1;
    private readonly RandomNumberService _randomNumberService2;

    public TestController
    (
        RandomNumberService randomNumberService1,
        RandomNumberService randomNumberService2
    )
    {
        _randomNumberService1 = randomNumberService1;
        _randomNumberService2 = randomNumberService2;
    }

    [Test(ExpectedResult = null)]
    public MockResponse GetRandomNumber()
    {
        return new MockResponse()
        {
            NumberOne = _randomNumberService1.GetNumber(),
            NumberTwo = _randomNumberService2.GetNumber()
        };
    }
}

public class MockResponse
{
    public int NumberOne { get; set; }
    public int NumberTwo { get; set; }
}
