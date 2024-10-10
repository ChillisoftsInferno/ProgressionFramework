// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System.Collections;
using DialogueSystem.Config;

namespace DialogueSystem.Settings;

public class InputKeyConfigurationSettings : IDictionary<ConsoleKey, string>
{
    private ValidConsoleKeysConfig _consoleKeysConfig;
    
    public InputKeyConfigurationSettings(string[] keys, ICollection<ConsoleKey> keys1, ICollection<string> values)
    {
        _consoleKeysConfig = new ValidConsoleKeysConfig();

        Keys = _consoleKeysConfig.GetKeys();
        Values = _consoleKeysConfig.GetValues();
    }

    public IEnumerator<KeyValuePair<ConsoleKey, string>> GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(KeyValuePair<ConsoleKey, string> item) => throw new NotImplementedException();

    public void Clear() => throw new NotImplementedException();

    public bool Contains(KeyValuePair<ConsoleKey, string> item) => throw new NotImplementedException();

    public void CopyTo(KeyValuePair<ConsoleKey, string>[] array, int arrayIndex) => throw new NotImplementedException();

    public bool Remove(KeyValuePair<ConsoleKey, string> item) => throw new NotImplementedException();

    public int Count { get; }
    public bool IsReadOnly { get; }
    public void Add(ConsoleKey key, string value) => throw new NotImplementedException();

    public bool ContainsKey(ConsoleKey key) => throw new NotImplementedException();

    public bool Remove(ConsoleKey key) => throw new NotImplementedException();

    public bool TryGetValue(ConsoleKey key, out string value) => throw new NotImplementedException();

    public string this[ConsoleKey key]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public ICollection<ConsoleKey> Keys { get; }
    public ICollection<string> Values { get; }
}
