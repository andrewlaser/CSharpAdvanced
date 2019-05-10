using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names =
            {
                "Layne", "Keri", "Quinn", "Jamel", "Charleen", "Charline", "Tatyana", "Delia", "Chery", "Monique",
                "Lurlene", "Andres", "Stuart", "Elvira", "Jolyn", "Polly", "Elayne", "Dorethea", "Verlene", "Diedra"
            };

            int[] numbers =
            {
                16, 40, 81, 66, 94, 15, 80, 94, 48, 18, 77, 30, 72, 61, 36, 37, 70, 75, 89, 46
            };

            object[] mix =
            {
                1, "string", 'd', new List<int>() {1, 2, 3, 4, 5}, new List<int>() {5, 1, 5, 9, 0}, "dd", 's', 1, 2, 3,
                5
            };

            List<Person> people = new List<Person>()
            {
                new Person("Name01", 180, 50, Gender.Female),
                new Person("Name06", 180, 60, Gender.Male),
                new Person("Name08", 180, 79, Gender.Female),
                new Person("Name", 150, 78, Gender.Male),
                new Person("Nam3", 100, 70, Gender.Female),
                new Person("Name15", 178, 73, Gender.Female),
                new Person("Name45", 190, 71, Gender.Female),
                new Person("Name67", 167, 74, Gender.Female),
                new Person("Name89", 189, 75, Gender.Female),
                new Person("Name10", 112, 77, Gender.Female),
                new Person("Name19", 145, 90, Gender.Female)
            };


            #region LINQ

            var getTheNmbers = from number in numbers
                where number < 10
                select number;

            var catsWithA = from name in names
                where name.Contains("a")
                orderby name
                select name;


            var fourCharPeolple = from p in people
                where p.Name.Length > 4
                orderby p.Name
                select p;

//            Console.WriteLine(string.Join("\n\n", fourCharPeolple));

            var oddNumbers = from n in numbers
                where n % 2 == 1
                select n;

            //Console.WriteLine(string.Join(", ", oddNumbers));

            #endregion

            #region Lambda

            List<int> oddnumbersLambda = numbers.Where(n => (n % 2 == 1)).ToList();
            //Console.WriteLine (string.Join(", ", oddNumbers));

            double average = names.Average(n => n.Length);

//            Console.WriteLine(numbers.Min(n => n));

            var allInts = mix.OfType<int>().Where(i => i<3).ToList();

//            Console.WriteLine(string.Join(",", allInts));

            var allIntLists = mix.OfType<List<int>>().ToList();

            foreach (var lst in allIntLists)
            {
//                Console.WriteLine($" list: {string.Join(", ", lst)}");
            }

            #endregion

            #region Select and Where


            var shortPeople = people.Where(person => person.Height < 180).ToList();

            var shortHeights = people.Where(person => person.Height < 180).Select(person => person.Height).OrderBy(height => height);
            //Console.WriteLine(string.Join(", ", shortPeople));
            //Console.WriteLine(string.Join(", ", shortHeights));

            //people.ForEach(person=>Console.WriteLine(person));

            //Console.WriteLine(string.Join(", ", numbers));
            numbers.Sort();
            //Console.WriteLine(string.Join(", ", numbers));

            #endregion

            #region Extensions

            Point point1 = new Point(20, 30);
            Point point2 = new Point(10, 15);

            Distance dist = point1.DistanceTo(point2);

            #endregion

            Console.ReadKey();
        }
    }
}