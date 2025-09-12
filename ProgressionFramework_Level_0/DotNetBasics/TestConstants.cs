// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace ProgressionFramework_Level_0.DotNetBasics;

[TestFixture]
public class TestConstants
{
    [TestFixture]
    public class TestConstantString
    {
        [Test]
        public void Given_ConstantString_Equals()
        {
            //Arrange
            const string constStringData = "data";
            string expected = "data";
            //Act
            var trueResult = constStringData.Equals("data");
            var falseResult = constStringData.Equals("");
            //Assert
            Assert.That(trueResult, Is.EqualTo(true));
            Assert.That(falseResult, Is.EqualTo(false));
        }

        [Test]
        public void Given_ConstantString_Clone()
        {
            //Arrange
            const string constStringData = "data";
            string expected = "data";
            //Act
            var clone = (string)constStringData.Clone();
            //Assert
            Assert.That(clone, Is.EqualTo(expected));
        }
    }
}
