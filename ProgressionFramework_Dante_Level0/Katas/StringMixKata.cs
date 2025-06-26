namespace ProgressionFramework_Dante_Level0.Katas;

public class StringMixKata
{
    public string Mix(string s1, string s2)
    {
        var mixDictionary = MergeWithMaxValues(SplitString(s1), SplitString(s2));
        var result = CreateMixString(mixDictionary);
        return result.Length > 0 ? result[..^1] : result;
    }
    
    public Dictionary<char, int> SplitString(string value)
    {
        return value.Split()
            .SelectMany(x => x.ToCharArray()
                .SkipWhile(c => c < 97))
            .OrderBy(x => x)
            .SkipWhile(x => x < 97 || x > 122)
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
    }

    public Dictionary<char, (string, int, int)> MergeWithMaxValues(
        Dictionary<char, int> dict1,
        Dictionary<char, int> dict2)
    {
        var result = new Dictionary<char, (string, int, int)>();
        var allKeys = new HashSet<char>(dict1.Keys.Concat(dict2.Keys));

        foreach (var key in allKeys)
        {
            dict1.TryGetValue(key, out int value1);
            dict2.TryGetValue(key, out int value2);

            if (value1 > value2)
            {
                result[key] = ("1:", value1, 1);
            }
            else if (value2 > value1)
            {
                result[key] = ("2:", value2, 2);
            }
            else
            {
                result[key] = ("=:", value1, 3);
            }
        }
        var finalResult = result
            .Where(kvp => kvp.Value.Item2 > 1)
            .OrderByDescending(kvp => kvp.Value.Item2)
            .ThenBy(kvp => kvp.Value.Item3)
            .ThenBy(kvp => kvp.Key)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        return finalResult;
    }

    public string CreateMixString(Dictionary<char, (string, int, int)> resultsDictionary)
    {
        string result = "";
        foreach (var kvp in resultsDictionary)
        {
            var amount = kvp.Value.Item2;
            var builder = kvp.Value.Item1;
            while (amount > 0)
            {
                builder += kvp.Key;
                amount--;
            }
            builder += "/";
            result += builder;
            
        }
        return result;
    }
}
