using System.Text.Json;
using DialogueSystem.Domain;

namespace ProgressionFramework_Dante_Level1.Json;

public class Deserialization(JsonSerializerOptions? options = null)
{
    private readonly JsonSerializerOptions _options = options ?? new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private string? _currentFilePath;
    private string? _jsonResults;

    public static JsonSerializerOptions GetJsonOptions(string jsonOptionsFilePath)
    {
        var fullPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, jsonOptionsFilePath));
        var json = File.ReadAllText(fullPath);
        return JsonSerializer.Deserialize<JsonSerializerOptions>(json) ?? throw new ArgumentNullException();
    }
    
    public void SetDeserializationFilePath(string filePath)
    {
        _currentFilePath = filePath;
    }

    public T? Deserialize<T>()
    {
        if(_currentFilePath == null) throw new ArgumentNullException();
        
        _jsonResults = File.ReadAllText(_currentFilePath);
        return JsonSerializer.Deserialize<T>(_jsonResults, _options);
    }
}