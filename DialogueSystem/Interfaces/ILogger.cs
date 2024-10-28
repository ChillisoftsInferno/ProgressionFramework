// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DialogueSystem.Interfaces;

public interface ILogger
{
    void Debug(string message, string? arg = null);
    void Info(string message, string? arg = null);
    void Warning(string message, string? arg = null);
    void Error(string message, string? arg = null);
}
