using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        public delegate void Printer(string str);


        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "Layne", "Keri", "Quinn", "Jamel", "Charleen", "Charline", "Tatyana", "Delia", "Chery", "Monique",
                "Lurlene", "Andres", "Stuart", "Elvira", "Jolyn", "Polly", "Elayne", "Dorethea", "Verlene", "Diedra", "a"
            };

            Func<string, bool> LessThan5 = s => s.Length < 5;
            Func<string, bool> MoreThan5 = s => s.Length > 5;
            Func<string, bool> Equal5 = s => s.Length == 5;


            var lessThanFiveChars = ExtractStrings(names, LessThan5);

            Console.WriteLine(string.Join(", ", lessThanFiveChars));

            Printer p = Print;
            p += Print;
            p("text");

            Action < string > print = s => Console.WriteLine(s);

            print("test");
            
            Console.ReadLine();
        }

        public delegate bool Filter(string str);


        public static List<string> ExtractStrings(List<string> input, Func<string, bool> filter)
        {
            List<string> lessThanFiveChars = new List<string>();
            foreach (var name in input)
            {
                if (filter(name))
                {
                    lessThanFiveChars.Add(name);
                }
            }
            return lessThanFiveChars;
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
