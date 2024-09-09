namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

[TestFixture]
public class Constants
{
    public const int MaxValue = 100;
    public const string GreetingMessage = "Hello, World!";
    
    // Confirms that the constant MaxValue is correctly assigned.
    [Test]
    public void TestConstants_MaxValue_ShouldBeCorrect()
    {
        //Arrange
        const int expectedMaxValue = 100;

        //Act
        int actualMaxValue = MaxValue;

        //Assert
        Assert.That(actualMaxValue, Is.EqualTo(expectedMaxValue));
    }

    // Confirms that the constant GreetingMessage is correctly assigned.
    [Test]
    public void TestConstants_GreetingMessage_ShouldBeCorrect()
    {
        //Arrange
        const string expectedMessage = "Hello, World!";

        //Act
        string actualMessage = GreetingMessage;

        //Assert
        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    }
}
