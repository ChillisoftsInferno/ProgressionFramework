// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Domain;
using DialogueSystem.Interfaces;

namespace DialogueSystem.Services;

public class PlayerController : IPlayerController
{
    private List<PlayerSave> _playerSaves;
    private PlayerSave _currentSave;

    public void SetPlayerSaves(List<PlayerSave> saves) => _playerSaves = saves;
    public List<PlayerSave> GetPlayerSaves() => _playerSaves;

    public void SetCurrentSave(PlayerSave save) => _currentSave = save;
    public PlayerSave GetCurrentSave() => _currentSave;
}