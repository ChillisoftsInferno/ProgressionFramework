// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Interfaces;

namespace DialogueSystem;

public class PlayerController : IPlayerController
{
    public List<PlayerSave> PlayerSaves { get; set; }
    public PlayerSave CurrentSave { get; set; }
}