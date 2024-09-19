namespace ProgressionFramework_Dante_Level0.Katas.Tests;

[TestFixture]
public class TestConwaysGameOfLife

{
    [Test]
    public void IfNodeIsEmpty_ReturnTrue()
    {
        //Arrange
        var xPos = 0;
        var yPos = 0;
        var expected = "_";
        var sut = new ConwaysGameOfLifeKata();
        //Act
        var actual = sut.GetCurrentNodeCharacter(xPos, yPos);
        //Assert
        Assert.IsTrue(actual.Equals(expected));
    }
}
