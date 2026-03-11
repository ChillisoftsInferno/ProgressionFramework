using DialogueSystem.Domain;
using ProgressionFramework_Dante_Level1.DataStructures;
using ProgressionFramework_Dante_Level1.Json;
using Xunit;

namespace ProgressionFramework_Dante_Level1.Tests;

public class CustomStackTests
{
    private readonly List<PlayerSave> _testData;
    private readonly string _playerSaveFilePath;
    private readonly string _jsonOptionsPath;

    public CustomStackTests()
    {
        _jsonOptionsPath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/JsonSerializationOptions.json");
        _playerSaveFilePath = Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json");

        var options = Deserialization.GetJsonOptions(_jsonOptionsPath);
        var deserializer = new Deserialization(options);
        deserializer.SetDeserializationFilePath(_playerSaveFilePath);
        _testData = deserializer.Deserialize<List<PlayerSave>>() ?? new List<PlayerSave>();
    }

    [Fact]
    public void Push_ShouldAddItemToStack()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();
        var item = _testData[0];

        // Act
        stack.Push(item);

        // Assert
        Assert.Equal(1, stack.Count);
        Assert.False(stack.IsEmpty);
        Assert.Equal(item, stack.Peek());
    }

    [Fact]
    public void Pop_ShouldRemoveAndReturnLastItem()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();
        foreach (var item in _testData)
        {
            stack.Push(item);
        }
        int initialCount = stack.Count;
        var lastItem = _testData.Last();

        // Act
        var poppedItem = stack.Pop();

        // Assert
        Assert.Equal(lastItem, poppedItem);
        Assert.Equal(initialCount - 1, stack.Count);
    }

    [Fact]
    public void Pop_EmptyStack_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_ShouldReturnLastItemWithoutRemovingIt()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();
        var item = _testData[0];
        stack.Push(item);

        // Act
        var peekedItem = stack.Peek();

        // Assert
        Assert.Equal(item, peekedItem);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Peek_EmptyStack_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Push_ShouldResizeStackWhenFull()
    {
        // Arrange
        var stack = new CustomStack<int>();
        int capacity = 4;

        // Act
        for (int i = 0; i < capacity + 1; i++)
        {
            stack.Push(i);
        }

        // Assert
        Assert.Equal(capacity + 1, stack.Count);
        Assert.Equal(capacity, stack.Peek());
    }

    [Fact]
    public void GetEnumerator_ShouldReturnItemsInCorrectOrder()
    {
        // Arrange
        var stack = new CustomStack<PlayerSave>();
        foreach (var item in _testData)
        {
            stack.Push(item);
        }

        // Act
        var list = stack.ToList();

        // Assert
        var expectedOrder = _testData.AsEnumerable().Reverse().ToList();
        Assert.Equal(expectedOrder.Count, list.Count);
        for (int i = 0; i < expectedOrder.Count; i++)
        {
            Assert.Equal(expectedOrder[i].SaveId, list[i].SaveId);
        }
    }
}
