using System;

namespace GlobalHelpers
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customer()
        {
            Name = string.Empty;
            Surname = string.Empty;
        }
        public Customer(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}