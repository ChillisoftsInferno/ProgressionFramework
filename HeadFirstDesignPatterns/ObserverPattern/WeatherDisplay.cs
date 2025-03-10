// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.ObserverPattern;

public class WeatherDisplay : IObserver
{
    private string _name;

    public WeatherDisplay(string name)
    {
        _name = name;
    }
    
    public void Update(float temperature)
    {
         Console.WriteLine($"{_name} updated: New temperature is {temperature}°C");  
    }
}
