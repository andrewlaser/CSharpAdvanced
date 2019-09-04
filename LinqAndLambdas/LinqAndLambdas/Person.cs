using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndLambdas
{
    public class Person
    {
        public string Name;
        public int Height;
        public int Weight;

        private Gender Gender;

        public Person(string name, int height, int weight)
        {
            Name = name;
            Height = height;
            Weight = weight;
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
