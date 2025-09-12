using ProgressionFramework_Dante_Level0.InterfaceHelpers;

namespace ProgressionFramework_Dante_Level0.HelperClasses.Animals;

// Derived class
public class Dog : Animal, IAnimal, IWalker
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
    public override string Speak()
    {
        return "Bark";
    }
}
