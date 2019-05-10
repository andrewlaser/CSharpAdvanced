using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndLambdas
{
    public static class Extensions
    {
        public static Distance DistanceTo(this Point p1, Point p2)
        {
            return new Distance()
            {
                Xdistance = Math.Abs(p2.X - p1.X),
                Ydistance = Math.Abs(p2.Y - p1.Y)
            };
        }

        public static void Sort(this int[] arr)
        {
            int temp;

            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
    }
}