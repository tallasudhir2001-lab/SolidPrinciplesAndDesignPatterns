using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.Facated
{
    public class Person
    {
        public string street, city, pincode;
        public string company, job;
        public int salary;

        public override string ToString()
        {
            return $"{job} at {company}, lives at {street}, {city}, {pincode}";
        }
    }
    public class PersonBuilder
    {
        protected Person person = new Person();
        public PersonAddressBuilder lives => new PersonAddressBuilder(person);
        public PersonJobBuilder works => new PersonJobBuilder(person);
        public Person Build()
        {
            return person;
        }
    }
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }
        public PersonAddressBuilder At(string street)
        {
            person.street = street;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            person.city = city;
            return this;
        }
        public PersonAddressBuilder WithPin(string pin)
        {
            person.pincode = pin;
            return this;
        }
    }
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }
        public PersonJobBuilder WorksAt(string company)
        {
            person.company = company;
            return this;
        }
        public PersonJobBuilder WorksAs(string job)
        {
            person.job = job;
            return this;
        }
        public PersonJobBuilder Salary(int salary)
        {
            person.salary = salary;
            return this;
        }
    }
    internal class ProgramFB
    {
        static void MainFB(string[] args)
        {
            var person = new PersonBuilder().lives.At("hitech ciy").In("Hyderabad").WithPin("500081").works.WorksAt("Vesik").WorksAs("SE").Salary(0000).Build();
            Console.WriteLine(person.ToString());
            Console.ReadLine();
        }
    }
}
