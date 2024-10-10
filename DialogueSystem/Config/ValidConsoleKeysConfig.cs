// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DialogueSystem.Config;

internal class ValidConsoleKeysConfig
{
    public ICollection<ConsoleKey> GetKeys() => new List<ConsoleKey>()
    {
        
    };
    
    public ICollection<string> GetValues() => new List<string>()
    {
        
    };
}

public enum SetKeys
{
    Y, //Yes
    N, //No
}
