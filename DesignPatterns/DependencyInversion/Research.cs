using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    //low-level
    public class Relationships : IRelationshipBrowser
    {
            
        private List<(Person person1, Relationship relationship, Person person2)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        IEnumerable<Person> IRelationshipBrowser.FindAllChildrenOf(string name)
        {
            return relations.Where(x => x.person1.Name == name && x.relationship == Relationship.Parent)
                .Select(r => r.person2);
        }
    }

    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine(p.Name);
            }
        }

        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where(x => x.person1.Name == "John" && x.relationship == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child {r.person2}");
        //    }
        //}

        static void Main(string[] args)
        {
            var parent = new Person {Name = "John"};
            var child1 = new Person {Name = "son1"};
            var child2 = new Person {Name = "son2"};

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
