using System.Text.Json;

namespace ProgressionFramework_Dante_Level1.Json;

public class JsonManager()
{
    private static JsonManager? _instance;
    private JsonSerializerOptions? _jsonOptions;

    public static JsonManager GetInstance()
    {
        return _instance ??= new JsonManager();
    }

    public JsonManager WithJsonOptions(string filePath)
    {
        if (_instance == null) throw new InvalidOperationException("JsonManager is not initialized.");
        _instance._jsonOptions = Deserialization.GetJsonOptions(filePath);
        return _instance;
    }

    public JsonSerializerOptions? GetJsonOptions()
    {
        return _jsonOptions;
    }
}