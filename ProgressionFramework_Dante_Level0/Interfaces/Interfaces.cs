namespace ProgressionFramework_Dante_Level0.Interfaces;

using NUnit.Framework;

[TestFixture]
public class Interfaces
{
    // Confirms that a class implementing an interface can be instantiated and used through the interface.
    [Test]
    public void TestInterface_Implementation_ShouldInstantiateAndUseInterfaceCorrectly()
    {
        //Arrange
        IAnimal animal = new Dog();
        var expectedSound = "Woof!";

        //Act
        var actualSound = animal.MakeSound();

        //Assert
        Assert.That(actualSound, Is.EqualTo(expectedSound));
    }

    // Confirms that a class correctly implements multiple interfaces.
    [Test]
    public void TestInterface_MultipleInterfaces_ShouldImplementAllMethodsCorrectly()
    {
        //Arrange
        IAnimal animal = new Dog();
        IWalker walker = new Dog();
        var expectedSound = "Woof!";
        var expectedWalk = "Dog is walking";

        //Act
        var actualSound = animal.MakeSound();
        var actualWalk = walker.Walk();

        //Assert
        Assert.That(actualSound, Is.EqualTo(expectedSound));
        Assert.That(actualWalk, Is.EqualTo(expectedWalk));
    }

    // Confirms that interface methods are invoked correctly for different implementations.
    [Test]
    public void TestInterface_DifferentImplementations_ShouldInvokeCorrectMethods()
    {
        //Arrange
        IAnimal dog = new Dog();
        IAnimal cat = new Cat();
        var expectedDogSound = "Woof!";
        var expectedCatSound = "Meow!";

        //Act
        var actualDogSound = dog.MakeSound();
        var actualCatSound = cat.MakeSound();

        //Assert
        Assert.That(actualDogSound, Is.EqualTo(expectedDogSound));
        Assert.That(actualCatSound, Is.EqualTo(expectedCatSound));
    }

    // Confirms that a method can accept an interface as a parameter and work with any implementation.
    [Test]
    public void TestInterface_MethodParameter_ShouldAcceptAnyImplementation()
    {
        //Arrange
        var animalHandler = new AnimalHandler();
        IAnimal dog = new Dog();
        IAnimal cat = new Cat();
        var expectedDogResponse = "Handling animal: Woof!";
        var expectedCatResponse = "Handling animal: Meow!";

        //Act
        var actualDogResponse = animalHandler.HandleAnimal(dog);
        var actualCatResponse = animalHandler.HandleAnimal(cat);

        //Assert
        Assert.That(actualDogResponse, Is.EqualTo(expectedDogResponse));
        Assert.That(actualCatResponse, Is.EqualTo(expectedCatResponse));
    }

    // Confirms that an interface property is correctly implemented and accessed in a class.
    [Test]
    public void TestInterface_PropertyImplementation_ShouldAccessPropertyCorrectly()
    {
        //Arrange
        IAnimal animal = new Dog();
        var expectedName = "Buddy";

        //Act
        animal.Name = expectedName;
        var actualName = animal.Name;

        //Assert
        Assert.That(actualName, Is.EqualTo(expectedName));
    }
}

// Example interfaces and classes used in the tests
public interface IAnimal
{
    string Name { get; set; }
    string MakeSound();
}

public interface IWalker
{
    string Walk();
}

public class Dog : IAnimal, IWalker
{
    public string Name { get; set; } = "Buddy";

    public string MakeSound()
    {
        return "Woof!";
    }

    public string Walk()
    {
        return "Dog is walking";
    }
}

public class Cat : IAnimal
{
    public string Name { get; set; } = "Kitty";

    public string MakeSound()
    {
        return "Meow!";
    }
}

public class AnimalHandler
{
    public string HandleAnimal(IAnimal animal)
    {
        return $"Handling animal: {animal.MakeSound()}";
    }
}

