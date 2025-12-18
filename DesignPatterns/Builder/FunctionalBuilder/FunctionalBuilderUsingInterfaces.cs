using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.FunctionalBuilder
{
    internal class ProgramFBUI
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Contact { get; set; }
            public override string ToString()
            {
                return $"Name :{Name},Age: {Age} Contact:{Contact}";
            }
        }
        public interface IName
        {
            IAge WithName(string name);
        }
        public interface IAge
        {
            IContact WithAge(int age);
        }
        public interface IContact
        {
            IBuilder WithContact(string contact);
        }
        public interface IBuilder
        {
            Person Build();
        }
        public class FunctionalBuilder : IName, IAge, IContact, IBuilder
        {
            List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
            public IAge WithName(string name)
            {
                actions.Add(p => { p.Name = name; return p; });
                return this;
            }
            public IContact WithAge(int age)
            {
                actions.Add(p => { p.Age = age; return p; });
                return this;
            }
            public IBuilder WithContact(string contact)
            {
                actions.Add(p => { p.Contact = contact; return p; });
                return this;
            }
            public Person Build()
            {
                var p = new Person();
                foreach (var action in actions)
                {
                    p = action(p);
                }
                return p;
            }
        }

        static void MainFBUI(string[] args)
        {
            Person p = new FunctionalBuilder().WithName("Sudhir").WithAge(5).WithContact("8374123236").Build();
            Console.WriteLine(p.ToString());
            Console.ReadLine();
        }
    }
}
