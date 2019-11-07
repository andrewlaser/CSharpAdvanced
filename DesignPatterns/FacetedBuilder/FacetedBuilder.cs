using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
    public class Person
    {
        //address
        public string StreetAddress, Postcode, City;
        
        //employment
        public string CompanyName, Position;

        public decimal AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder //facade
    {
        //reference
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder builder)
        {
            return builder.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder AtAddress(string address)
        {
            person.StreetAddress = address;
            return this;
        }

        public PersonAddressBuilder UnderPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder InTheCity(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(decimal amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    class FacetedBuilder
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb;

            pb.Works.At("nix").AsA("AQA").Earning(100000).Lives.AtAddress("XXX Street").UnderPostcode("00000")
                .InTheCity("Lviv");

            Console.WriteLine(person);
            Console.ReadKey();
        }
    }
}
