using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }

    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecificaiton : ISpecification<Product>
    {
        private Color _color;

        public ColorSpecificaiton(Color color)
        {
            _color = color;
        }


        public bool IsSatisfied(Product t)
        {
            return t.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {

        private Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == _size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _first, _second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            _first = first;
            _second = second;
        }

        public bool IsSatisfied(T t)
        {
            return _first.IsSatisfied(t) && _second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }

    class OpenClosed
    {

        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product("Apple", Color.Green, Size.Small),
                new Product("Tree", Color.Green, Size.Huge),
                new Product("House", Color.Blue, Size.Huge)
            };

            var pf = new ProductFilter();
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            var bf = new BetterFilter();
            foreach (var p in bf.Filter(products, new ColorSpecificaiton(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            var bf2 = new BetterFilter();
            foreach (var p in bf2.Filter(products,
                new AndSpecification<Product>(new ColorSpecificaiton(Color.Green), new SizeSpecification(Size.Huge))))
            {
                Console.WriteLine($" - {p.Name} is green and huge");
            }


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
