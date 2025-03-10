// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.ObserverPattern;

public class WeatherStation : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private float _temperature;

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);    
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public void SetTemperature(float currentTemperature)
    {
        _temperature = currentTemperature;
        NotifyObservers();
    }
}
