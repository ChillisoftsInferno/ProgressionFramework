using ProgressionFramework_Dante_Level0.HelperClasses;

namespace ProgressionFramework_Dante_Level0.Classes;

[TestFixture]
public class Classes
{
    [Test]
    public void TestClass_InstanceCreation_ShouldInitializeCorrectly()
    {
        //Arrange
        var expectedName = "John";
        var expectedAge = 25;

        //Act
        var person = new Person(expectedName, expectedAge);

        //Assert
        Assert.That(person.Name, Is.EqualTo(expectedName));
        Assert.That(person.Age, Is.EqualTo(expectedAge));
    }

    // Confirms that a method in a class returns the expected result.
    [Test]
    public void TestClass_MethodCall_ShouldReturnCorrectResult()
    {
        //Arrange
        var person = new Person("John", 25);
        var expectedGreeting = "Hello, my name is John and I am 25 years old.";

        //Act
        var actualGreeting = person.GetGreeting();

        //Assert
        Assert.That(actualGreeting, Is.EqualTo(expectedGreeting));
    }

    // Confirms that properties of a class can be set and retrieved correctly.
    [Test]
    public void TestClass_PropertySetAndGet_ShouldWorkCorrectly()
    {
        //Arrange
        var person = new Person("John", 20);
        var expectedName = "Jane";
        var expectedAge = 30;

        //Act
        person.Name = expectedName;
        person.Age = expectedAge;

        //Assert
        Assert.That(person.Name, Is.EqualTo(expectedName));
        Assert.That(person.Age, Is.EqualTo(expectedAge));
    }

    // Confirms that two instances of a class are considered equal based on custom equality logic.
    [Test]
    public void TestClass_Equality_ShouldReturnTrueForEqualObjects()
    {
        //Arrange
        var person1 = new Person("Jane", 25);
        var person2 = new Person("Jane", 25);

        //Act
        var areEqual = person1.Equals(person2);

        //Assert
        Assert.IsTrue(areEqual);
    }

    // Confirms that a static method in a class returns the expected result.
    [Test]
    public void TestClass_StaticMethod_ShouldReturnCorrectResult()
    {
        //Arrange
        var number1 = 10;
        var number2 = 20;
        var expectedSum = 30;

        //Act
        var actualSum = MathUtility.AddNumbers(number1, number2);

        //Assert
        Assert.That(actualSum, Is.EqualTo(expectedSum));
    }
}