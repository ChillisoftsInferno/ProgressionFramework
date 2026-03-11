using DialogueSystem.Domain;
using ProgressionFramework_Dante_Level1.DataStructures;
using ProgressionFramework_Dante_Level1.Json;
using Xunit;

namespace ProgressionFramework_Dante_Level1.Tests;

public class CustomLinkedListTests
{
    private readonly List<PlayerSave> _testData;
    private readonly string _playerSaveFilePath;
    private readonly string _jsonOptionsPath;

    public CustomLinkedListTests()
    {
        _jsonOptionsPath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/JsonSerializationOptions.json");
        _playerSaveFilePath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json");

        var options = Deserialization.GetJsonOptions(_jsonOptionsPath);
        var deserializer = new Deserialization(options);
        deserializer.SetDeserializationFilePath(_playerSaveFilePath);
        _testData = deserializer.Deserialize<List<PlayerSave>>() ?? new List<PlayerSave>();
    }

    [Fact]
    public void AddFirst_ShouldAddItemToBeginning()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        var item1 = _testData[0];
        var item2 = _testData[1];

        // Act
        list.AddFirst(item1);
        list.AddFirst(item2);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(item2.SaveId, list.First().SaveId);
        Assert.Equal(item1.SaveId, list.Last().SaveId);
    }

    [Fact]
    public void AddLast_ShouldAddItemToEnd()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        var item1 = _testData[0];
        var item2 = _testData[1];

        // Act
        list.AddLast(item1);
        list.AddLast(item2);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(item1.SaveId, list.First().SaveId);
        Assert.Equal(item2.SaveId, list.Last().SaveId);
    }

    [Fact]
    public void Remove_ShouldRemoveExistingItem()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        var item1 = _testData[0];
        var item2 = _testData[1];
        var item3 = _testData[2];
        list.AddLast(item1);
        list.AddLast(item2);
        list.AddLast(item3);

        // Act
        bool result = list.Remove(item2);

        // Assert
        Assert.True(result);
        Assert.Equal(2, list.Count);
        var remainingItems = list.ToList();
        Assert.Equal(item1.SaveId, remainingItems[0].SaveId);
        Assert.Equal(item3.SaveId, remainingItems[1].SaveId);
    }

    [Fact]
    public void Remove_Head_ShouldRemoveCorrectly()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        var item1 = _testData[0];
        list.AddLast(item1);

        // Act
        bool result = list.Remove(item1);

        // Assert
        Assert.True(result);
        Assert.Equal(0, list.Count);
        Assert.Empty(list);
    }

    [Fact]
    public void Remove_NonExistingItem_ShouldReturnFalse()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        var item1 = _testData[0];
        var item2 = _testData[1];
        list.AddLast(item1);

        // Act
        bool result = list.Remove(item2);

        // Assert
        Assert.False(result);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Clear_ShouldEmptyList()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        foreach (var item in _testData)
        {
            list.AddLast(item);
        }
        Assert.True(list.Count > 0);

        // Act
        list.Clear();

        // Assert
        Assert.Equal(0, list.Count);
        Assert.Empty(list);
    }

    [Fact]
    public void GetEnumerator_ShouldReturnItemsInCorrectOrder()
    {
        // Arrange
        var list = new CustomLinkedList<PlayerSave>();
        foreach (var item in _testData)
        {
            list.AddLast(item);
        }

        // Act
        var resultList = list.ToList();

        // Assert
        Assert.Equal(_testData.Count, resultList.Count);
        for (int i = 0; i < _testData.Count; i++)
        {
            Assert.Equal(_testData[i].SaveId, resultList[i].SaveId);
        }
    }
}
