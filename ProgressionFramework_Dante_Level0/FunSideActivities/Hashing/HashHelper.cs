// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace ProgressionFramework_Dante_Level0.FunSideActivities.Hashing;

public static class HashHelper
{
    public static bool ExistsInSet(this string hashCode, HashSet<string> hashSet)
    {
        if (hashSet.FirstOrDefault(c => c == hashCode) != null) return true;
        return false;
    }
}
