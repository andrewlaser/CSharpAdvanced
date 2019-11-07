using System;
using System.Collections.Generic;
using System.Threading;

namespace DesignPatterns
{
    public class Person
    {
        public string Name;

        public string Position;

        public DateTime DateOfBirth;
    
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<TSelf> : PersonBuilder
        where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf Called(string name)
        {
            person.Name = name;
            return (TSelf) this;
        }
    }

    public class PersonJobBuilder<TSelf> 
        : PersonInfoBuilder<PersonJobBuilder<TSelf>>
        where TSelf : PersonJobBuilder<TSelf>
    {
        public TSelf WorksAsA(string position)
        {
            person.Position = position;
            return (TSelf) this;
        }
    }

    // here's another inheritance level
    // note there's no PersonInfoBuilder<PersonJobBuilder<PersonBirthDateBuilder<TSelf>>>!

    public class PersonBirthDateBuilder<TSelf> 
        : PersonJobBuilder<PersonBirthDateBuilder<TSelf>>
        where TSelf : PersonBirthDateBuilder<TSelf>
    {
        public TSelf Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (TSelf)this;
        }
    }

    public class PersonBuilderDirector : PersonBirthDateBuilder<PersonBuilderDirector>
    {
        public static PersonBuilderDirector New => new PersonBuilderDirector();
    }

    internal class Program
    {
        //class SomeBuilder : PersonBirthDateBuilder<SomeBuilder>
        //{

        //}

        public static void Main(string[] args)
        {
            var me = PersonBuilderDirector.New
                .Called("Dmitri")
                .WorksAsA("Quant")
                .Born(DateTime.UtcNow).Called("Andrew").WorksAsA("AQA")
                .Build();
            Console.WriteLine(me);

            Console.ReadLine();
        }
    }
}