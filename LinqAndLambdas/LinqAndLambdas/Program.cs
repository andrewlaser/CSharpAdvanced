using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
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

            List<Person> people = new List<Person>
            {
                new Person("N1", 160, 100),
                new Person("N2", 170, 90),
                new Person("N3", 180, 80),
                new Person("N4", 190, 70)
            };


            #region LINQ
            var someNames = from name in names
                            where name.Contains("a")
                            orderby name descending 
                            select name;

            Console.WriteLine(string.Join(", ", someNames));

            var shorties = from p in people
                where p.Height <= 170
                orderby p.Height
                select p.Name;

            Console.WriteLine(string.Join("\n", shorties));

            var oddNumbers = from n in numbers
                where n % 2 == 1
                select n;

            Console.WriteLine(String.Join(", ", oddNumbers));

            #endregion

            #region Lambda

            oddNumbers = numbers.Where(n => n % 2 == 1);
            Console.WriteLine(String.Join(", ", oddNumbers));

            double aver = numbers.Average();
            Console.WriteLine(aver);

            var allInts = mix.OfType<int>().Where(i => i < 3);
            Console.WriteLine(string.Join(", ", allInts));

            var shortPeople = people.Where(p => p.Height < 170).
                Select(p => p.Height).ToList();
            Console.WriteLine(string.Join(", ", shortPeople));

            

            #endregion

            numbers.Sort();
            Console.WriteLine(string.Join(", ", numbers));

            Point point1 = new Point(20, 30);
            Point point2 = new Point(202, 301);
            Point point3 = new Point(203, 302);
            Point point4 = new Point(204, 303);

            Console.WriteLine(point1.DistanceTo(point2));

            Console.ReadKey();
            
        }
    }
}