using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> checkintegers = (i, j) => i < j;

            Console.WriteLine( checkintegers(4,5));

            Action printSth = () => Console.WriteLine("something");
            printSth();

            Action<int, int> PrintSum = (i, j) =>
            {
                Console.WriteLine(i);
                Console.WriteLine(j);
                Console.WriteLine(i + j);
            };

            PrintSum(1, 2);

            List<string> names = new List<string>
            {
                "Layne", "Keri", "Quinn", "Jamel", "Charleen", "Charline", "Tatyana", "Delia", "Chery", "Monique",
                "Lurlene", "Andres", "Stuart", "Elvira", "Jolyn", "Polly", "Elayne", "Dorethea", "Verlene", "Diedra", "a"
            };

            Func<List<string>, Func<string, bool>, List<string>> extractStrings = (arr, filter) =>
            {
                List<string> result = new List<string>();

                foreach (var item in arr)
                {
                    if (filter(item))
                    {
                        result.Add(item);
                    }
                }

                return result;
            };

            Func<string, bool> LessThan5 = s => s.Length < 5;

            var shortNames = extractStrings(names, LessThan5);
            Console.WriteLine(string.Join(", ", shortNames));


            Console.ReadKey();

        }
    }
}
