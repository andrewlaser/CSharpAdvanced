using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class PointFactory
    {
        public static Point NewCortesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    public class Point
    {
        private double x, y;

        //factory method

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    class Factory
    {

        static void Main(string[] args)
        {
            var point = PointFactory.NewCortesianPoint(4, 5);
            var point2 = PointFactory.NewPolarPoint(3, Math.PI / 2);
            Console.WriteLine(point);
            Console.WriteLine(point2);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}

