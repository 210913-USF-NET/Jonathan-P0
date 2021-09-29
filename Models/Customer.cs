using System;

namespace Models
{
    public class Customer
    {
        public Customer(){}

        public Customer(string name)
        {
            this.Name = name;
        }

        public Customer(string name, string city, string state) : this(name)
        {
            this.City = city;
            this.State =state;
        }

        public string Name {get; set;}
        public string State{get; set;}
        public string City{get; set;}
        public string Cu_ID {get; set;}

        public override string ToString()
        {
            return $"Name: {Name}  Customer ID: {Cu_ID}  City: {City}  State: {State}";
        }
    }
}
