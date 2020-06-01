using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using NUnit.Framework;
using static System.Console;
//using Autofac;

namespace Singleton
{
    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.AreEqual(1, SingletonDatabase.Count);
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var cf = new ConfigurableRecordFinder(new DummyDataBase());
            var names = new[] {"alpha", "gamma"};
            int totalPopulation = cf.GetTotalPopulation(names);
            Assert.AreEqual(totalPopulation, 4);
        }

        [Test]
        public void ConfigurablePopulationTest()
        {
            SingletonRecordFinder singletonRecordFinder = new SingletonRecordFinder();
            int population = singletonRecordFinder.GetTotalPopulation(new List<string>() {"Seoul", "Tokyo"});
            Assert.AreEqual(33200000+17500000, population);

        }


    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }
            return result;
        }
    }

    public class DummyDataBase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                {"alpha", 1},
                {"beta", 2},
                {"gamma", 3}
            }[name];
        }
        
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }
            return result;
        }
    }

    public interface IDatabase
    {
        int GetPopulation(string city);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;
        private static int instanceCount = 0;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            Console.WriteLine($"Initialize Data access #{instanceCount}");
            _capitals = File.ReadAllLines(TestContext.CurrentContext.TestDirectory +  @"\Capitals.txt").Batch(2)
                .ToDictionary(list => list.ElementAt(0).Trim(), list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string city)
        {
            return _capitals[city];
        }

        private static Lazy<SingletonDatabase> _instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => _instance.Value;
    }

    class Singleton
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingletonDatabase.Instance.GetPopulation("Mexico City"));


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
