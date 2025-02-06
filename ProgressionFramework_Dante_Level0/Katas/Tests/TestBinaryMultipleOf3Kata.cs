// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System.Text.RegularExpressions;

namespace ProgressionFramework_Dante_Level0.Katas.Tests;

[TestFixture]
public class TestBinaryMultipleOf3Kata
{
    [Test, Order(1)]
    public void CheckType()
    {
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().GetType(), Is.EqualTo(typeof(Regex)));
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().Match("").GetType(), Is.EqualTo(typeof(Match)));
    }
  
    [Test, Order(2)]
    public void InvalidCharacters()
    {
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch(" 0"), Is.False);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("abc"), Is.False);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("011 110"), Is.False);
    }
  
    [Test, Order(3)]
    public void SmallNumbers()
    {
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("000"), Is.True);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("001"), Is.False);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("010"), Is.False);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("011"), Is.True);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("110"), Is.True);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch("111"), Is.False);
    }
  
    [Test, Order(4)]
    public void LargeNumbers()
    {
        string binary12345678 = Convert.ToString(12345678, 2);
        string binary12345679 = Convert.ToString(12345679, 2);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch(binary12345678), Is.True);
        Assert.That(BinaryMultipleOf3Kata.MultipleOf3().IsMatch(binary12345679), Is.False);
    }
}
