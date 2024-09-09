using ProgressionFramework_Dante_Level0.HelperClasses.Animals;

namespace ProgressionFramework_Dante_Level0.Inheritance_Polymorphism;

[TestFixture]
public class Inheritance
{
    // Confirms that the base class can be instantiated and returns the expected value.
    [Test]
    public void TestBaseClass_Instantiation_ShouldReturnExpectedValue()
    {
        //Arrange
        var animal = new Animal();
        var expected = "Unknown sound";

        //Act
        var result = animal.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that the derived class (Dog) overrides the method correctly.
    [Test]
    public void TestDerivedClass_DogSpeak_ShouldReturnBark()
    {
        //Arrange
        var dog = new Dog();
        var expected = "Bark";

        //Act
        var result = dog.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that the derived class (Cat) overrides the method correctly.
    [Test]
    public void TestDerivedClass_CatSpeak_ShouldReturnMeow()
    {
        //Arrange
        var cat = new Cat();
        var expected = "Meow";

        //Act
        var result = cat.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a derived class can access base class methods.
    [Test]
    public void TestDerivedClass_AccessBaseMethod_ShouldReturnBaseResult()
    {
        //Arrange
        Animal dogAsAnimal = new Dog();
        var expected = "Bark";

        //Act
        var result = dogAsAnimal.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a derived class can be cast to its base class.
    [Test]
    public void TestDerivedClass_CastToBaseClass_ShouldReturnExpectedValue()
    {
        //Arrange
        Animal animal = new Dog();
        var expected = "Bark";

        //Act
        var result = animal.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that attempting to cast an unrelated class to a derived class fails.
    [Test]
    public void TestInvalidCast_ShouldThrowInvalidCastException()
    {
        //Arrange
        Animal animal = new Dog();

        //Act & Assert
        Assert.Throws<InvalidCastException>(() =>
        {
            Cat cat = (Cat)(object)animal;
        });
    }
}
