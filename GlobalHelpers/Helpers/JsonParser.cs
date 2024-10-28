// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System;
using System.Collections.Generic;
using System.IO;
using GlobalHelpers.Interfaces;
using Newtonsoft.Json;

namespace GlobalHelpers.Helpers;

public class JsonParser<T> where T : class , IJsonParser<T>
{
    public List<T> LoadJson (string jsonFilePath)
    {
        using (StreamReader r = new StreamReader(jsonFilePath))
        {
            string json = r.ReadToEnd();
            
            var dataList = JsonConvert.DeserializeObject<List<T>>(json) ?? throw new ArgumentNullException();
            return dataList;
        }
    }
}
