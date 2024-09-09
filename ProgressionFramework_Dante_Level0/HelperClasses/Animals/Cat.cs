using ProgressionFramework_Dante_Level0.InterfaceHelpers;

namespace ProgressionFramework_Dante_Level0.HelperClasses.Animals;

// Derived class
public class Cat : Animal, IAnimal
{
    public string Name { get; set; } = "Kitty";

    public string MakeSound()
    {
        return "Meow!";
    }
    public override string Speak()
    {
        return "Meow";
    }
}
