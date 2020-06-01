using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCodingExercise
{
    public class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public class PersonFactory
    {
        private static int _idCounter = 0;

        public Person CreatePerson(string name)
        {
            Person person = new Person(_idCounter, name);
            _idCounter++;
            return person;

        }
    }
    
    class FactoryCodingExercise
    {
        static void Main(string[] args)
        {
            PersonFactory personFactory = new PersonFactory();
            Person person1 = personFactory.CreatePerson("name1");
            Person person2 = personFactory.CreatePerson("name2");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            
            
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
