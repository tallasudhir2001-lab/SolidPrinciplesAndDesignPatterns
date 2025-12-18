using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    //public class Person 
    //{
    //    public string FirstName;
    //    public string LastName;
    //    public int Age;
    //    public string Job;
    //    public string EMail;
    //    public int Mobile;
    //    public string State;
    //    public string City;
    //    public Person(string FirstName, string LastName, int age, string Job, string EMail, int Mobile, string State, string City)
    //    {
    //        this.FirstName = FirstName;
    //        this.LastName = LastName;
    //        this.Age = age;
    //        this.Job = Job;   
    //        this.EMail = EMail;
    //        this.Mobile = Mobile;
    //        this.State = State;
    //        this.City = City;                
    //    }
    //}
    public class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Job;
        public string EMail;
        public int Mobile;
        public string State;
        public string City;
    }

    public class PersonBuilder
    {
        Person person = new Person();
        public PersonBuilder WithName(string firstName, string LastName)
        {
            person.FirstName = firstName;
            person.LastName = LastName;
            return this;
        }
        public PersonBuilder WithAge(int Age)
        {
            person.Age = Age;
            return this;
        }
        public PersonBuilder WithJoB(string job)
        {
            person.Job = job;
            return this;
        }
        public PersonBuilder WithContact(string email, int phone)
        {
            person.EMail = email;
            person.Mobile = phone;
            return this;
        }
        public PersonBuilder WithAddress(string State, string city)
        {
            person.State = State;
            person.City = city;
            return this;
        }
        public Person Build()
        {
            return person;
        }
    }
    internal class ProgramB
    {
        static void MainB(string[] args)
        {
            //this one is ugly and hard to maintain
            //var person = new Person("Sudhir", "Talla",25,"Software Dev","xyz",83741,"Telangana","Hyd");

            //instead of building person object like this we can create Person object builder class

            var personBuilder = new PersonBuilder().WithName("Sudhir", "Talla").WithAge(25).WithJoB("Dev").WithContact("xyz", 83741).WithAddress("TG", "Hyd").Build();
        }
    }
}
