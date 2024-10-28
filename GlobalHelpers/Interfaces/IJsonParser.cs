// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System.Collections.Generic;

namespace GlobalHelpers.Interfaces;

public interface IJsonParser<T>
{
    public List<T> LoadJson(string jsonFilePath);
}
