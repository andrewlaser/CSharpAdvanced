using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class Person
    {
        public string Name;
        public string Position;
        public DateTime DateOfBirth;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(DateOfBirth)}: {DateOfBirth}";
        }
    }

    public class PersonBuilder<T>: PersonBuilder where T: PersonBuilder<T>
    {
        public T SetName(string name)
        {
            Person.Name = name;
            return (T) this;
        }

        public T AtPosition(string position)
        {
            Person.Position = position;
            return (T) this;
        }

        public T Born(DateTime date)
        {
            Person.DateOfBirth = date;
            return (T) this;
        }
    }


    public abstract class PersonBuilder
    {
        protected Person Person;

        public PersonBuilder()
        {
            Person = new Person();
        }

        public Person Build() => Person;
    }

    public class PersonBuilderDirector : PersonBuilder<PersonBuilderDirector>
    {
        public static PersonBuilderDirector NewPerson => new PersonBuilderDirector();
    }

    class FBuilder
    {
        //static void Main(string[] args)
        //{
        //    var employee = PersonBuilderDirector.NewPerson.SetName("Name").AtPosition("position").Born(DateTime.Now)
        //        .Build();
        //    Console.WriteLine(employee.ToString());
        //    Console.ReadKey();

        //}
    }
}
