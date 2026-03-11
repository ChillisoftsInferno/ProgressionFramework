using DialogueSystem.Domain;
using ProgressionFramework_Dante_Level1.DataStructures;
using ProgressionFramework_Dante_Level1.Json;
using Xunit;

namespace ProgressionFramework_Dante_Level1.Tests;

public class DataStructureConverterTests
{
    private readonly List<PlayerSave> _testData;
    private readonly string _playerSaveFilePath;
    private readonly string _jsonOptionsPath;

    public DataStructureConverterTests()
    {
        _jsonOptionsPath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/JsonSerializationOptions.json");
        _playerSaveFilePath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json");

        var options = Deserialization.GetJsonOptions(_jsonOptionsPath);
        var deserializer = new Deserialization(options);
        deserializer.SetDeserializationFilePath(_playerSaveFilePath);
        _testData = deserializer.Deserialize<List<PlayerSave>>() ?? new List<PlayerSave>();
    }

    [Fact]
    public void ToQueue_FromList_ShouldReturnCorrectQueue()
    {
        // Act
        var queue = DataStructureConverter.ToQueue(_testData);

        // Assert
        Assert.Equal(_testData.Count, queue.Count);
        int i = 0;
        foreach (var item in queue)
        {
            Assert.Equal(_testData[i].SaveId, item.SaveId);
            i++;
        }
    }

    [Fact]
    public void ToStack_FromList_ShouldReturnCorrectStack()
    {
        // Act
        var stack = DataStructureConverter.ToStack(_testData);

        // Assert
        Assert.Equal(_testData.Count, stack.Count);
        var expectedOrder = _testData.AsEnumerable().Reverse().ToList();
        int i = 0;
        foreach (var item in stack)
        {
            Assert.Equal(expectedOrder[i].SaveId, item.SaveId);
            i++;
        }
    }

    [Fact]
    public void ToLinkedList_FromList_ShouldReturnCorrectLinkedList()
    {
        // Act
        var list = DataStructureConverter.ToLinkedList(_testData);

        // Assert
        Assert.Equal(_testData.Count, list.Count);
        int i = 0;
        foreach (var item in list)
        {
            Assert.Equal(_testData[i].SaveId, item.SaveId);
            i++;
        }
    }

    [Fact]
    public void ConvertToStack_FromQueue_ShouldMaintainOrder()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();
        foreach (var item in _testData) queue.Enqueue(item);

        // Act
        var stack = DataStructureConverter.ConvertToStack(queue);

        // Assert
        Assert.Equal(_testData.Count, stack.Count);
        var expectedOrder = _testData.AsEnumerable().Reverse().ToList();
        int i = 0;
        foreach (var item in stack)
        {
            Assert.Equal(expectedOrder[i].SaveId, item.SaveId);
            i++;
        }
    }

    [Fact]
    public void ConvertToQueue_FromStack_ShouldMaintainOrder()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();
        foreach (var item in _testData) stack.Push(item);

        // Act
        var queue = DataStructureConverter.ConvertToQueue(stack);

        // Assert
        Assert.Equal(_testData.Count, queue.Count);
        var expectedOrder = _testData.AsEnumerable().Reverse().ToList();
        int i = 0;
        foreach (var item in queue)
        {
            Assert.Equal(expectedOrder[i].SaveId, item.SaveId);
            i++;
        }
    }

    [Fact]
    public void ConvertToLinkedList_FromStack_ShouldMaintainOrder()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();
        foreach (var item in _testData) stack.Push(item);

        // Act
        var list = DataStructureConverter.ConvertToLinkedList(stack);

        // Assert
        Assert.Equal(_testData.Count, list.Count);
        var expectedOrder = _testData.AsEnumerable().Reverse().ToList();
        int i = 0;
        foreach (var item in list)
        {
            Assert.Equal(expectedOrder[i].SaveId, item.SaveId);
            i++;
        }
    }

    [Fact]
    public void ConvertToLinkedList_FromQueue_ShouldMaintainOrder()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();
        foreach (var item in _testData) queue.Enqueue(item);

        // Act
        var list = DataStructureConverter.ConvertToLinkedList(queue);

        // Assert
        Assert.Equal(_testData.Count, list.Count);
        int i = 0;
        foreach (var item in list)
        {
            Assert.Equal(_testData[i].SaveId, item.SaveId);
            i++;
        }
    }
}
