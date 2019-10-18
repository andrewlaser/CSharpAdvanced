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
        public decimal Salary;

        public class Builder : PersonJobBuilder<Builder>
        {
           
        }

        public static Builder New => new Builder();

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

    public class PersonInfoBuilder<T> : PersonBuilder
        where T : PersonInfoBuilder<T>
    {
        protected Person Person = new Person();

        public T Called(string name)
        {
            Person.Name = name;
            return (T) this;
        }

        public T HasSalary(decimal salary)
        {
            Person.Salary = salary;
            return (T) this;
        }

    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>>
        where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            Person.Position = position;
            return (T) this;
        }
    }
    
    class FluentBuilder
    {

        //static void Main(string[] args)
        //{
        //    var me = Person.New.Called("Andrew").WorksAsA("AQA").HasSalary(1000);


            


        //    Console.ReadKey();

        //}
    }
}
