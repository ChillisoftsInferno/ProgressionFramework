using ProgressionFramework_Dante_Level0.HelperClasses;
using ProgressionFramework_Dante_Level0.HelperClasses.Node;

namespace ProgressionFramework_Dante_Level0.Generics;

[TestFixture]
public class Generics
{
    // Confirms that a generic class can store and retrieve an item of a specific type.
    [Test]
    public void TestGenerics_StoreAndRetrieveItem_ShouldWorkCorrectly()
    {
        //Arrange
        var genericContainer = new Node<int>();
        int expected = 42;

        //Act
        genericContainer.Item = expected;
        var actual = genericContainer.Item;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    // Confirms that a generic method can add items of any type to a list.
    [Test]
    public void TestGenerics_AddItemToList_ShouldAddCorrectly()
    {
        //Arrange
        var list = new List<string>();
        var expected = "TestString";

        //Act
        NodeUtilities.AddItemToList(list, expected);

        //Assert
        Assert.Contains(expected, list);
    }

    // Confirms that a generic method can return the correct type when used with different data types.
    [Test]
    public void TestGenerics_ReturnCorrectType_ShouldReturnCorrectValue()
    {
        //Arrange
        int intInput = 5;
        string stringInput = "Test";
        
        //Act
        int intResult = NodeUtilities.GetDefaultValue(intInput);
        string stringResult = NodeUtilities.GetDefaultValue(stringInput);

        //Assert
        Assert.That(intResult, Is.EqualTo(intInput));
        Assert.That(stringResult, Is.EqualTo(stringInput));
    }

    // Confirms that a generic constraint ensures the correct type is used.
    [Test]
    public void TestGenerics_EnsuresCorrectType_ShouldWorkWithStructs()
    {
        //Arrange
        var point = new Point(3, 4);
        var expected = point;

        //Act
        var actual = NodeUtilities.GetDefaultValue(point);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    // Confirms that a generic class works correctly with reference types.
    [Test]
    public void TestGenerics_WithReferenceType_ShouldStoreAndRetrieveCorrectly()
    {
        //Arrange
        var genericContainer = new Node<Person>();
        var expectedPerson = new Person("John", 30);

        //Act
        genericContainer.Item = expectedPerson;
        var actualPerson = genericContainer.Item;

        //Assert
        Assert.That(actualPerson.Name, Is.EqualTo(expectedPerson.Name));
        Assert.That(actualPerson.Age, Is.EqualTo(expectedPerson.Age));
    }

    // Confirms that a generic collection can store and retrieve multiple items of a specific type.
    [Test]
    public void TestGenerics_StoreAndRetrieveMultipleItems_ShouldWorkCorrectly()
    {
        //Arrange
        var list = new List<int> { 1, 2, 3 };
        var expectedCount = 3;

        //Act
        var actualCount = list.Count;

        //Assert
        Assert.That(actualCount, Is.EqualTo(expectedCount));
    }

    // Confirms that a generic method works with a custom class.
    [Test]
    public void TestGenericMethod_WithCustomClass_ShouldWorkCorrectly()
    {
        //Arrange
        var person = new Person("Alice", 25);
        var expectedName = "Alice";

        //Act
        var resultPerson = NodeUtilities.GetDefaultValue(person);

        //Assert
        Assert.That(resultPerson.Name, Is.EqualTo(expectedName));
    }
}
