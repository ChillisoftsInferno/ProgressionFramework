// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace HeadFirstDesignPatterns.ObserverPattern;

public class ObserverPatternUseCase : IDesignPatternUseCase
{

    public static void Execute()
    {
        WeatherStation weatherStation = new WeatherStation();

        WeatherDisplay display1 = new WeatherDisplay("Display 1");
        WeatherDisplay display2 = new WeatherDisplay("Display 2");

        weatherStation.RegisterObserver(display1);
        weatherStation.RegisterObserver(display2);

        // Change temperature
        weatherStation.SetTemperature(25.0f);
        weatherStation.SetTemperature(30.0f);

        // Remove one display and update again
        weatherStation.RemoveObserver(display1);
        weatherStation.SetTemperature(28.0f);
    }
}
