// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Domain;

namespace DialogueSystem.Interfaces;

public interface IJsonParser
{
    public void LoadJson();
    public List<PlayerSave> LoadAllPlayerSaves();
    public PlayerSave LoadPlayerSaveById(int saveId);
    public PlayerSave GetLatestPlayerSave();
    public void SavePlayerData(PlayerSave save, bool nextSave);
}
