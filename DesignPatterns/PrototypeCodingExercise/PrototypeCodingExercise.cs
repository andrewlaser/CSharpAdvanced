using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrototypeCodingExercise
{
    [TestFixture]
    public class FirstTestSuite
    {
        [Test]
        public void Test()
        {
            var line1 = new Line
            {
                Start = new Point { X = 3, Y = 3},
                End = new Point { X = 10, Y = 10}
            };

            var line2 = line1.DeepCopy();
            line1.Start.X = line1.End.X = line1.Start.Y = line1.End.Y = 0;

            Assert.That(line2.Start.X, Is.EqualTo(3));
            Assert.That(line2.Start.Y, Is.EqualTo(3));
            Assert.That(line2.End.X, Is.EqualTo(10));
            Assert.That(line2.End.Y, Is.EqualTo(10));
        }
    }

    public static class CloningExtension
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(memoryStream, self);
                memoryStream.Position = 0;
                var ret = serializer.Deserialize(memoryStream);
                return (T) ret;
            }
        }
    }

    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        //public Point DeepCopy()
        //{
        //    return new Point(X, Y);
        //}

        public Point()
        {
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }

    public class Line
    {
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Start, End;

        //public Line DeepCopy()
        //{
        //    return new Line(Start.DeepCopy(), End.DeepCopy());
        //}

        public Line()
        {
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
        }
    }


    class PrototypeCodingExercise
    {
        static void Main(string[] args)
        {
            var line = new Line(new Point(1,2), new Point(3,4));
            var line2 = line.DeepCopy();
            line2.Start.X = 0;
            line2.Start.Y = 0;
            
            Console.WriteLine(line);
            Console.WriteLine(line2);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
