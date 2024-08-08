namespace GlobalHelpers
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customer()
        {
            
        }
        public Customer(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}