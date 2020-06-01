using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeInterface
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }


    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Array.Copy(other.Names, Names, other.Names.Length);
            Address = new Address(other.Address);
        }

        public Person DeepCopy()
        {
            string[] newNames = new string[Names.Length];
            Array.Copy(Names, newNames, Names.Length);
            return new Person(newNames, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {String.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }


    class PrototypeInterface
    {
        static void Main(string[] args)
        {
            var john = new Person(new [] {"john", "Smith"}, new Address("street", 123));
            var jane = john.DeepCopy();
            jane.Names = new[] {"Jane", "not Smith"};
            jane.Address.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(jane);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
