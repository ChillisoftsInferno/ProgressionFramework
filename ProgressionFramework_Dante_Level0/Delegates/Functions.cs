namespace ProgressionFramework_Dante_Level0.Delegates;

[TestFixture]
public class Functions
{
    // Confirms that a Func with no parameters returns the expected value.
    [Test]
    public void TestFunc_NoParameters_ShouldReturnExpectedValue()
    {
        //Arrange
        Func<int> func = () => 42;
        int expected = 42;

        //Act
        var result = func();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a Func with one parameter returns the expected value.
    [Test]
    public void TestFunc_OneParameter_ShouldReturnExpectedValue()
    {
        //Arrange
        Func<int, int> func = (x) => x * 2;
        int input = 10;
        int expected = 20;

        //Act
        var result = func(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a Func with multiple parameters returns the expected value.
    [Test]
    public void TestFunc_MultipleParameters_ShouldReturnExpectedValue()
    {
        //Arrange
        Func<int, int, int> func = (x, y) => x + y;
        int input1 = 10;
        int input2 = 20;
        int expected = 30;

        //Act
        var result = func(input1, input2);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a Func can return a string based on input.
    [Test]
    public void TestFunc_ReturnsString_ShouldReturnExpectedString()
    {
        //Arrange
        Func<int, string> func = (x) => $"Number: {x}";
        int input = 5;
        string expected = "Number: 5";

        //Act
        var result = func(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a Func can return a calculated value.
    [Test]
    public void TestFunc_CalculatesValue_ShouldReturnCorrectCalculation()
    {
        //Arrange
        Func<int, int, int> func = (x, y) => x * y;
        int input1 = 3;
        int input2 = 7;
        int expected = 21;

        //Act
        var result = func(input1, input2);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
