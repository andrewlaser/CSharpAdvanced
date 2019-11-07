using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AbstractFactory
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
        public enum AvailableDrinks
        {
            Coffee,
            Tea
        }

        private Dictionary<AvailableDrinks, IHotDrinkFactory> factories = new Dictionary<AvailableDrinks, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrinks drink in Enum.GetValues(typeof(AvailableDrinks)))
            {
                var factory =
                    (IHotDrinkFactory) Activator.CreateInstance(
                        Type.GetType("AbstractFactory." + Enum.GetName(typeof(AvailableDrinks), drink) + "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrinks drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }

    }


    class AbstractFactory
    {
        static void Main(string[] args)
        {
            HotDrinkMachine hotDrinkMachine = new HotDrinkMachine();
            hotDrinkMachine.MakeDrink(HotDrinkMachine.AvailableDrinks.Coffee, 2).Consume();
            WriteLine("");
            ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
