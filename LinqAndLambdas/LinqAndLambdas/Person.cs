using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndLambdas
{
    public class Person
    {
        private string name;
        private int height;
        private int weight;

        private Gender gender;


        public Person(string name, int height, int weight, Gender gender)
        {
            this.name = name;
            this.height = height;
            this.weight = weight;
            this.gender = gender;
        }

        public override string ToString()
        {
            return $"Name: {name} \n height: {height} \n weight: {weight} \n gender: {gender.ToString()}";
        }

        public Gender Gender
        {
            get => gender;
            set => gender = value;
        }

        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
