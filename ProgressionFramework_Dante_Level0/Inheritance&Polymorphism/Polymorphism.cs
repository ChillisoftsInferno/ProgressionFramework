using ProgressionFramework_Dante_Level0.HelperClasses.Animals;

namespace ProgressionFramework_Dante_Level0.Inheritance_Polymorphism;

public class Polymorphism
{
     // Confirms that a method in a derived class is called when using polymorphism.
    [Test]
    public void TestPolymorphism_DerivedClassMethod_ShouldBeCalled()
    {
        //Arrange
        Animal animal = new Dog();
        var expected = "Bark";

        //Act
        var result = animal.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a method in another derived class is called when using polymorphism.
    [Test]
    public void TestPolymorphism_AnotherDerivedClassMethod_ShouldBeCalled()
    {
        //Arrange
        Animal animal = new Cat();
        var expected = "Meow";

        //Act
        var result = animal.Speak();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Confirms that a collection of base class objects can hold derived class instances.
    [Test]
    public void TestPolymorphism_CollectionOfBaseClass_ShouldWorkWithDerivedClasses()
    {
        //Arrange
        var animals = new Animal[] { new Dog(), new Cat() };
        var expectedSounds = new string[] { "Bark", "Meow" };

        //Act
        var actualSounds = new string[2];
        for (int i = 0; i < animals.Length; i++)
        {
            actualSounds[i] = animals[i].Speak();
        }

        //Assert
        CollectionAssert.AreEqual(expectedSounds, actualSounds);
    }

    // Confirms that a derived class can be passed as a parameter to a method expecting a base class.
    [Test]
    public void TestPolymorphism_PassDerivedClassAsBaseClassParameter_ShouldWorkCorrectly()
    {
        //Arrange
        var dog = new Dog();
        var cat = new Cat();
        var expectedDogSound = "Bark";
        var expectedCatSound = "Meow";

        //Act
        var actualDogSound = MakeAnimalSpeak(dog);
        var actualCatSound = MakeAnimalSpeak(cat);

        //Assert
        Assert.That(actualDogSound, Is.EqualTo(expectedDogSound));
        Assert.That(actualCatSound, Is.EqualTo(expectedCatSound));
    }

    // Helper method for TestPolymorphism_PassDerivedClassAsBaseClassParameter_ShouldWorkCorrectly
    private string MakeAnimalSpeak(Animal animal)
    {
        return animal.Speak();
    }
}
