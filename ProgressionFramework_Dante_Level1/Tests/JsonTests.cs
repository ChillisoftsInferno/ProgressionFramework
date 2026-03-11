using System.Text.Json;
using DialogueSystem.Domain;
using ProgressionFramework_Dante_Level1.Json;
using Xunit;

namespace ProgressionFramework_Dante_Level1.Tests;

public class JsonTests
{
    private readonly string _playerSaveFilePath;
    private readonly string _jsonOptionsPath;
    private readonly string _tempFilePath;

    public JsonTests()
    {
        _jsonOptionsPath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/JsonSerializationOptions.json");
        _playerSaveFilePath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json");
        _tempFilePath = Path.Combine(AppContext.BaseDirectory, "temp_save.json");
    }

    [Fact]
    public void JsonManager_GetInstance_ShouldReturnSameInstance()
    {
        var instance1 = JsonManager.GetInstance();
        var instance2 = JsonManager.GetInstance();
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void JsonManager_WithJsonOptions_ShouldSetOptions()
    {
        var manager = JsonManager.GetInstance();
        manager.WithJsonOptions(_jsonOptionsPath);
        Assert.NotNull(manager.GetJsonOptions());
    }

    [Fact]
    public void Deserialization_GetJsonOptions_ShouldReturnValidOptions()
    {
        var options = Deserialization.GetJsonOptions(_jsonOptionsPath);
        Assert.NotNull(options);
        Assert.True(options.PropertyNameCaseInsensitive);
    }

    [Fact]
    public void Deserialization_Deserialize_ShouldReturnData()
    {
        // Arrange
        var options = Deserialization.GetJsonOptions(_jsonOptionsPath);
        var deserializer = new Deserialization(options);
        deserializer.SetDeserializationFilePath(_playerSaveFilePath);

        // Act
        var results = deserializer.Deserialize<List<PlayerSave>>();

        // Assert
        Assert.NotNull(results);
        Assert.NotEmpty(results);
        Assert.Equal(5, results[0].SaveId);
    }

    [Fact]
    public void Serialization_SaveToJson_ShouldCreateFile()
    {
        // Arrange
        var data = new List<PlayerSave>
        {
            new PlayerSave { SaveId = 99, SaveName = "Test Save" }
        };
        var serializer = new Serialization();

        // Act
        serializer.SaveToJson(data, _tempFilePath);

        // Assert
        Assert.True(File.Exists(_tempFilePath));
        var content = File.ReadAllText(_tempFilePath);
        Assert.Contains("99", content);
        Assert.Contains("Test Save", content);

        // Cleanup
        File.Delete(_tempFilePath);
    }
    
    [Fact]
    public void Deserialization_Deserialize_WithoutPath_ShouldThrow()
    {
        var deserializer = new Deserialization();
        Assert.Throws<ArgumentNullException>(() => deserializer.Deserialize<List<PlayerSave>>());
    }
}
