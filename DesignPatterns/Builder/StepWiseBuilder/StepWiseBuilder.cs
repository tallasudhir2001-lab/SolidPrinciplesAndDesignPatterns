using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.StepWiseBuilder
{
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
        public override string ToString()
        {
            return $"Fn :{FirstName}, Ln:{LastName},Age: {Age} Job:{Job},email :{EMail},contact :{Mobile}, State :{State}, City :{City}";
        }
    }
    public interface INameStep
    {
        IAgeStep WithName(String firstName, String LastName);
    }
    public interface IAgeStep
    {
        IJobStep WithAge(int age);
    }
    public interface IJobStep
    {
        IContactStep WithJob(string job);
    }
    public interface IContactStep
    {
        IAddressStep WithContact(string email, int mobile);
    }
    public interface IAddressStep
    {
        IPersonBuilder WithAddress(string state, string city);
    }
    public interface IPersonBuilder
    {
        Person Build();
    }



    public class PersonBuilder : INameStep, IAgeStep, IJobStep, IContactStep, IAddressStep, IPersonBuilder
    {
        Person person = new Person();
        public IAgeStep WithName(string firstName, string LastName)
        {
            person.FirstName = firstName;
            person.LastName = LastName;
            return this;
        }
        public IJobStep WithAge(int Age)
        {
            person.Age = Age;
            return this;
        }
        public IContactStep WithJob(string job)
        {
            person.Job = job;
            return this;
        }
        public IAddressStep WithContact(string email, int phone)
        {
            person.EMail = email;
            person.Mobile = phone;
            return this;


        }
        public IPersonBuilder WithAddress(string state, string city)
        {
            person.State = state;
            person.City = city;
            return this;
        }
        public Person Build()
        {
            return this.person;
        }

    }
    internal class ProgramSB
    {
        static void MainSB(string[] args)
        {
            //this one is ugly and hard to maintain
            //var person = new Person("Sudhir", "Talla",25,"Software Dev","xyz",83741,"Telangana","Hyd");

            //instead of building person object like this we can create Person object builder class

            Person personBuilder = new PersonBuilder().WithName("Sudhir", "Talla").WithAge(25).WithJob("Dev").WithContact("xyz", 83741).WithAddress("TG", "Hyd").Build();
            //Here it forces steps because WithName method returns PersonBuilder but you can't access all the methods in it becuase withname method returns the Interface WithAge
            //Ex IAgeStep ageStep= PersonBuilder();
            //Even though Object is PersonBuilder, Ref is IAgeStpe which has only one method which is WithAge.
            Console.WriteLine(personBuilder.ToString());
            Console.ReadLine();
        }
    }
}
