using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.FunctionalBuilder
{
    internal class ProgramFB
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
        public class FunctionalBuilder
        {
            List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
            public FunctionalBuilder WithName(string name)
            {
                actions.Add(p => { p.Name = name; return p; });
                return this;
            }
            public FunctionalBuilder WithAge(int age)
            {
                actions.Add(p => { p.Age = age; return p; });
                return this;
            }
            public FunctionalBuilder WithContact(string contact)
            {
                actions.Add(p => { p.Contact = contact; return p; });
                return this;
            }
            public Person Builder()
            {
                var p = new Person();
                foreach (var action in actions)
                {
                    p = action(p);
                }
                return p;
            }
        }

        static void MainFB(string[] args)
        {
            Person p = new FunctionalBuilder().WithName("Sudhir").WithAge(5).WithContact("8374123236").Builder();
            Console.WriteLine(p.ToString());
            Console.ReadLine();
        }
    }
}
