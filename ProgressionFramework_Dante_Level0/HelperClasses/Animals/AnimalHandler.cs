// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using ProgressionFramework_Dante_Level0.InterfaceHelpers;

namespace ProgressionFramework_Dante_Level0.HelperClasses.Animals;

public class AnimalHandler
{
    public string HandleAnimal(IAnimal animal)
    {
        return $"Handling animal: {animal.MakeSound()}";
    }
}
