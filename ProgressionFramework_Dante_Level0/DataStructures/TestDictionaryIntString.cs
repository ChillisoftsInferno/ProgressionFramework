// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using FluentAssertions;

namespace ProgressionFramework_Dante_Level0.DataStructures;

[TestFixture]
public class TestDictionaryIntString
{
    [Test]
    public void ShouldAddKeyValuePair()
    {
        //Arrange
        var dictionary = new Dictionary<int, string>();

        //Act
        dictionary.Add(1, "One");

        //Assert
        dictionary.ContainsKey(1).Should().BeTrue();
        dictionary[1].Should().Be("One");
    }

    [Test]
    public void ShouldRetrieveValueByKey()
    {
        //Arrange
        var dictionary = new Dictionary<int, string> { { 2, "Two" } };

        //Act
        var value = dictionary[2];

        //Assert
        value.Should().Be("Two");
    }

    [Test]
    public void ShouldUpdateValueForExistingKey()
    {
        //Arrange
        var dictionary = new Dictionary<int, string> { { 3, "Three" } };

        //Act
        dictionary[3] = "Updated";

        //Assert
        dictionary[3].Should().Be("Updated");
    }

    [Test]
    public void ShouldRemoveKeyValuePair()
    {
        //Arrange
        var dictionary = new Dictionary<int, string> { { 4, "Four" } };

        //Act
        var result = dictionary.Remove(4);

        //Assert
        result.Should().BeTrue();
        dictionary.ContainsKey(4).Should().BeFalse();
    }

    [Test]
    public void ShouldReturnFalse_WhenKeyNotFound()
    {
        //Arrange
        var dictionary = new Dictionary<int, string>();

        //Act
        var containsKey = dictionary.ContainsKey(99);

        //Assert
        containsKey.Should().BeFalse();
    }

    [Test]
    public void ShouldThrowException_WhenAddingDuplicateKey()
    {
        //Arrange
        var dictionary = new Dictionary<int, string> { { 5, "Five" } };

        //Act
        Action act = () => dictionary.Add(5, "Duplicate");

        //Assert
        act.Should().Throw<ArgumentException>();
    }
}
