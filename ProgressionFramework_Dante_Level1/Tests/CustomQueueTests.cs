using DialogueSystem.Domain;
using ProgressionFramework_Dante_Level1.DataStructures;
using ProgressionFramework_Dante_Level1.Json;
using Xunit;

namespace ProgressionFramework_Dante_Level1.Tests;

public class CustomQueueTests
{
    private readonly List<PlayerSave> _testData;
    private readonly string _playerSaveFilePath;
    private readonly string _jsonOptionsPath;

    public CustomQueueTests()
    {
        _jsonOptionsPath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/JsonSerializationOptions.json");
        _playerSaveFilePath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json");

        var options = Deserialization.GetJsonOptions(_jsonOptionsPath);
        var deserializer = new Deserialization(options);
        deserializer.SetDeserializationFilePath(_playerSaveFilePath);
        _testData = deserializer.Deserialize<List<PlayerSave>>() ?? new List<PlayerSave>();
    }

    [Fact]
    public void Enqueue_ShouldAddItemToQueue()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();
        var item = _testData[0];

        // Act
        queue.Enqueue(item);

        // Assert
        Assert.Equal(1, queue.Count);
        Assert.False(queue.IsEmpty);
        Assert.Equal(item, queue.Peek());
    }

    [Fact]
    public void Dequeue_ShouldRemoveAndReturnFirstItem()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();
        foreach (var item in _testData)
        {
            queue.Enqueue(item);
        }
        int initialCount = queue.Count;
        var firstItem = _testData.First();

        // Act
        var dequeuedItem = queue.Dequeue();

        // Assert
        Assert.Equal(firstItem, dequeuedItem);
        Assert.Equal(initialCount - 1, queue.Count);
    }

    [Fact]
    public void Dequeue_EmptyQueue_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ShouldReturnFirstItemWithoutRemovingIt()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();
        var item = _testData[0];
        queue.Enqueue(item);

        // Act
        var peekedItem = queue.Peek();

        // Assert
        Assert.Equal(item, peekedItem);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Peek_EmptyQueue_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Enqueue_ShouldResizeQueueWhenFull()
    {
        // Arrange
        var queue = new CustomQueue<int>();
        int capacity = 4;

        // Act
        for (int i = 0; i < capacity + 1; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        Assert.Equal(capacity + 1, queue.Count);
        Assert.Equal(0, queue.Peek());
    }

    [Fact]
    public void WrapAround_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new CustomQueue<int>();
        int capacity = 4;
        for (int i = 0; i < capacity; i++) queue.Enqueue(i);
        
        queue.Dequeue();
        queue.Enqueue(4);
        
        // Act
        queue.Enqueue(5);
        
        // Assert
        Assert.Equal(5, queue.Count);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
        Assert.Equal(4, queue.Dequeue());
        Assert.Equal(5, queue.Dequeue());
    }

    [Fact]
    public void GetEnumerator_ShouldReturnItemsInCorrectOrder()
    {
        // Arrange
        var queue = new CustomQueue<PlayerSave>();
        foreach (var item in _testData)
        {
            queue.Enqueue(item);
        }

        // Act
        var list = queue.ToList();

        // Assert
        Assert.Equal(_testData.Count, list.Count);
        for (int i = 0; i < _testData.Count; i++)
        {
            Assert.Equal(_testData[i].SaveId, list[i].SaveId);
        }
    }
}
