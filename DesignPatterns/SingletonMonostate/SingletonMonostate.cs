using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SingletonMonostate
{
    class SingletonMonostate
    {
        public class CEO
        {
            private static string name;
            private static int age;


            public int Age
            {
                get => age;
                set => age = value;
            }

            public string Name 
            {
                get => name;
                set => name = value;
            }

            public override string ToString()
            {
                return $"{nameof(Age)}: {Age}, {nameof(Name)}: {Name}";
            }
        }


        static void Main(string[] args)
        {
            var ceo1 = new CEO();
            ceo1.Name = "name1";
            ceo1.Age = 20;
            var ceo2 = new CEO();

            Console.WriteLine(ceo2);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
