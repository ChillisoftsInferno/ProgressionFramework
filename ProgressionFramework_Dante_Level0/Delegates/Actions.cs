namespace ProgressionFramework_Dante_Level0.Delegates;

[TestFixture]
public class Actions
{
    // Confirms that an Action with no parameters executes correctly.
    [Test]
    public void TestAction_NoParameters_ShouldExecuteCorrectly()
    {
        //Arrange
        bool actionExecuted = false;
        Action action = () =>
        {
            actionExecuted = true;
        };

        //Act
        action();

        //Assert
        Assert.IsTrue(actionExecuted);
    }

    // Confirms that an Action with one parameter executes correctly.
    [Test]
    public void TestAction_OneParameter_ShouldExecuteCorrectly()
    {
        //Arrange
        int result = 0;
        Action<int> action = (x) =>
        {
            result = x + 5;
        };
        int input = 10;
        int expected = 15;

        //Act
        action(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that an Action with multiple parameters executes correctly.
    [Test]
    public void TestAction_MultipleParameters_ShouldExecuteCorrectly()
    {
        //Arrange
        int sum = 0;
        Action<int, int> action = (x, y) =>
        {
            sum = x + y;
        };
        int input1 = 10;
        int input2 = 20;
        int expected = 30;

        //Act
        action(input1, input2);

        //Assert
        Assert.That(sum, Is.EqualTo(expected));
    }

    // Confirms that an Action can be used to modify an external list.
    [Test]
    public void TestAction_ModifiesList_ShouldAddElementToList()
    {
        //Arrange
        var list = new List<int>();
        Action<int> action = (x) =>
        {
            x += x;
            list.Add(x);
        };
        int input = 20;
        int expected = 40;

        //Act
        action(input);

        //Assert
        Assert.Contains(expected, list);
    }

    // Confirms that an Action can throw an exception when required.
    [Test]
    public void TestAction_ThrowsException_ShouldThrowExpectedException()
    {
        //Arrange
        Action action = () =>
        {
            throw new InvalidOperationException("Test Exception");
        };

        //Act & Assert
        Assert.Throws<InvalidOperationException>(() => action());
    }
}

