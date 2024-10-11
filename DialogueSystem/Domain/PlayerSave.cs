// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DialogueSystem.Domain;

public class PlayerSave
{
    public int SaveId { get; set; }
    public List<SaveData> SavedData { get; set; }
}
