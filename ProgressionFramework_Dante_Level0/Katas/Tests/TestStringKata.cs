// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace ProgressionFramework_Dante_Level0.Katas.Tests;

[TestFixture]

public class TestStringKata
{
    [TestCase("", 0)]
    public void Add_GivenEmptyString_ShouldReturnZero(string input, int expectedSum)
    {
        //Arrange
        var sut = new StringKata();
        //Act
        var result = sut.Add(input);
        //Assert
        Assert.That(result, Is.EqualTo(expectedSum));
    }
    
    [TestCase("1", 1)]
    [TestCase("25", 25)]
    [TestCase("999", 999)]
    public void Add_GivenOneNumber_ShouldReturnThatNumber(string input, int expectedSum)
    {
        //Arrange
        var sut = new StringKata();
        //Act
        var result = sut.Add(input);
        //Assert
        Assert.That(result, Is.EqualTo(expectedSum));
    }
    
    [TestCase("1, 2, 3", 6)]
    [TestCase("25, 25, 50", 100)]
    [TestCase("999, 1, 250", 1250)]
    public void Add_GivenMultipleNumbers_ShouldReturnSumOfNumbers(string input, int expectedSum)
    {
        //Arrange
        var sut = new StringKata();
        //Act
        var result = sut.Add(input);
        //Assert
        Assert.That(result, Is.EqualTo(expectedSum));
    }
    
    [TestCase("//;\n1; 2; 3", 6)]
    [TestCase("//[]\n25[] 25, 50", 100)]
    [TestCase("//{}\n999, 1{} 250", 1250)]
    public void Add_GivenCustomDelimiter_ShouldReturnSumOfNumbers(string input, int expectedSum)
    {
        //Arrange
        var sut = new StringKata();
        //Act
        var result = sut.Add(input);
        //Assert
        Assert.That(result, Is.EqualTo(expectedSum));
    }
    
    [TestCase("//;\n1; -2; 3", "-2")]
    [TestCase("//[]\n25[] 25, -50", "-50")]
    [TestCase("//{}\n999, -1{} -250", "-1,-250")]
    public void Add_GivenNegativeNumber_ShouldThrowExceptionContainingNegativeNumbers(string input, string expectedExceptionText)
    {
        //Arrange
        var sut = new StringKata();
        //Act
        var ex = Assert.Throws<Exception>(() => sut.Add(input));
        //Assert
        Assert.That(ex.Message, Is.EqualTo(expectedExceptionText));
    }
}
