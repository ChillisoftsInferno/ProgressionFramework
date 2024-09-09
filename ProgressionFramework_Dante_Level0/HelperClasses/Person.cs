namespace ProgressionFramework_Dante_Level0.HelperClasses;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string GetGreeting()
    {
        return $"Hello, my name is {Name} and I am {Age} years old.";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Person otherPerson)
        {
            return Name == otherPerson.Name && Age == otherPerson.Age;
        }
        return false;
    }

    protected bool Equals(Person other) => Name == other.Name && Age == other.Age;

    public override int GetHashCode() => HashCode.Combine(Name, Age);
}
