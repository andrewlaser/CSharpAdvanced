using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace AbstractFactoryOcp
{

    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Consume Tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Consume Coffee");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine("tea bag, boil water, ... drink");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine("coffee, boil water, ... drink");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        //private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
        private List<(string, IHotDrinkFactory)> factories = new List<(string, IHotDrinkFactory)>();
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add((t.Name.Replace("Factory", String.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks");
            foreach (var factory in factories)
            {
                WriteLine($"{factory.Item1}");
            }
            while (true)
            {
                string s;
                if((s=Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >=0
                    && i < factories.Count)
                {
                    Write("specify amount: ");
                    s = ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0
                        )
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                    WriteLine($"Incorrect input: {s}");
                }
                    
            }
        }


    }


    class AbstractFactoryOcp
    {
        static void Main(string[] args)
        {
            HotDrinkMachine hotDrinkMachine = new HotDrinkMachine();
            var drink = hotDrinkMachine.MakeDrink();
            WriteLine("");
            ReadKey();

        }
    }
}
