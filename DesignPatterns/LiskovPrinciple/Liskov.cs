using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LiskovPrinciple
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set => base.Width = base.Height = value;
        }

        public override int Height
        {
            set => base.Width = base.Height = value;
        }
    }

    class Liskov
    {
        public static int Area(Rectangle rect)
        {
            return rect.Height * rect.Width;
        }

        static void Main(string[] args)
        {

            Rectangle rc = new Rectangle(4, 5);
            Console.WriteLine();
            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{rc}, {Area(rc)}");
            Console.WriteLine($"{sq}, {Area(sq)}");

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
