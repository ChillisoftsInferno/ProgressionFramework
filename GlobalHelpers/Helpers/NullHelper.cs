// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

#nullable enable
namespace GlobalHelpers.Helpers;

public static class NullHelper
{
    public static bool IsNull(this object? data) => data == null;
}
