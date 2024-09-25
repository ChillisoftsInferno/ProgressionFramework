// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System.Text;

namespace ProgressionFramework_Dante_Level0.FunSideActivities.Hashing;

public static class HashHelper
{
    public static bool ExistsInHashSet(this byte[] hash, HashSet<string> hashSet, Encoding encoding)
    {
        if (hashSet.Count == 0) return false;
        
        foreach (var set in hashSet)
        {
            var hSet = set.ConvertToByteArray();
            if (hSet.Length != hash.Length) continue;
            if (hash.IsNotEqual(hSet)) continue;
            return true;
        }
        return false;
    }

    public static bool IsNotEqual(this byte[] setToCheck, byte[] set)
    {
        for (int i = 0; i < set.Length; i++)
        {
            if (setToCheck[i] != set[i]) return true;
        }
        return false;
    }

    public static byte[] ConvertToByteArray(this string hash)
    {
        var decodedArr =  hash.Replace('.', ' ').Split(' ');
        byte[] byteArr = new byte[decodedArr.Length];
        for (int i = 0; i < byteArr.Length;i++)
        {
            byteArr[i] = Convert.ToByte(decodedArr[i]);
        }

        return byteArr;
    }

    public static string CreateNewEntry(this byte[] bytes)
    {
        string hashCode = ""; 

        foreach (var b in bytes)
        {
            hashCode += b + ".";
        }
        hashCode = hashCode.TrimEnd('.');
        return hashCode;
    }

    public static string WithoutDots(this string data)
    {
        return data.Replace(".", "");
    }
    
    
}
