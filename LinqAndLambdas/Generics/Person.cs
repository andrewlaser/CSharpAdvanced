using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
        public class Person : IComparable<Person>
        {
            public string Name;
            public int Age;
            public int Height;
            public int Weight;

            private Gender Gender;

            public Person(string name, int height, int weight, int age)
            {
                Age = age;
                Name = name;
                Height = height;
                Weight = weight;
            }

            public int CompareTo(Person other)
            {
                if (Age < other.Age)
                {
                    return -1;
                }
                if( Age == other.Age)
                {
                    return 0;
                }
                    return 1;
            }

            public override string ToString()
            {
                return $"Name: '{Name}'; Height: '{Height}'; Weight: '{Weight}'";
            }
        }

        public enum Gender
        {
            Male,
            Female
        }
    }
