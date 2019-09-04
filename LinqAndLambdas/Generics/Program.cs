using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Generics
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

            Person[] people =
            {
                new Person("Name01", 180, 50, 56),
                new Person("Name06", 180, 60, 87),
                new Person("Name08", 180, 79, 9),
                new Person("Name", 150, 78, 100),
                new Person("Nam3", 100, 70, 34),
                new Person("Name15", 178, 73, 98),
                new Person("Name45", 190, 71, 1),
                new Person("Name67", 167, 74, 6),
                new Person("Name89", 189, 75, 12),
                new Person("Name10", 112, 77, 23),
                new Person("Name19", 145, 90, 45)
            };

            var sorted = Sort(names);
            Console.WriteLine(string.Join(", ", sorted));

            var person1 = new Person("Name01", 180, 50, 56);
            var person2 = new Person("Name06", 180, 60, 87);
            
            Console.WriteLine(person1.CompareTo(person2));

            MyList<int> myIntList = new MyList<int>();
            Console.WriteLine(myIntList.Capacity);
            Console.WriteLine(myIntList.Count);

            myIntList.Add(1);
            myIntList.Add(2);
            Console.WriteLine(myIntList.Capacity);
            Console.WriteLine(myIntList.Count);

            myIntList.Add(3);
            myIntList.Add(4);
            myIntList[3] = 999;

            MyList<int> myIntList2 = new MyList<int>();
            myIntList2.Add(111);
            myIntList2.Add(222);

            MyList<int> appended = myIntList + myIntList2;

            Console.WriteLine(myIntList.Capacity);
            Console.WriteLine(myIntList.Count);
            Console.WriteLine(appended);

    




            Console.ReadKey();

        }

        public static bool AreEqual<T>(T o1, T o2) where T: IComparable<T>
        {
            return o1.CompareTo(o2) == 0;
        }


        public static T[] Sort<T>(T[] a) where T: IComparable
        {
            T t;
            for (int p = 0; p <= a.Length - 2; p++)
            {
                for (int i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i].CompareTo(a[i + 1]) > 0)
                    {
                        t = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = t;
                    }
                } 
            }
            return a;
        }

    }
}
