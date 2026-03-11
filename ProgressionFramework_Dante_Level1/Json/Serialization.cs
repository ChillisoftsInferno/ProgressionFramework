using System.Text.Json;

namespace ProgressionFramework_Dante_Level1.Json;

public class Serialization(JsonSerializerOptions? options = null)
{
    private readonly JsonSerializerOptions _options = options ?? new JsonSerializerOptions();

    public void SaveToJson<T>(T data, string filePath)
    {
        var jsonResults = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(filePath, jsonResults);
    }
}