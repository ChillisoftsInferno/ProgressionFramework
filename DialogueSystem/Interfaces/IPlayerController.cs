// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Domain;

namespace DialogueSystem.Interfaces;

public interface IPlayerController
{
    public void SetPlayerSaves(List<PlayerSave> saves);
    public List<PlayerSave> GetPlayerSaves();

    public void SetCurrentSave(PlayerSave save);
    public PlayerSave GetCurrentSave();
}
