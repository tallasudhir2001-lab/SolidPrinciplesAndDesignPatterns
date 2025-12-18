using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    //A single class that decides which object to create and returns a common interface.
    public class Point
    {
        double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        //this is good but what if i have different type of co- ordinates lime angles theeta and pie which also has two double args.
        //I cannot distignuish with a contrustor right so we need a 3rd parameter or 2 classes extending Point(normal and polar)
        //or we can just have a method that constructs the respective object

        //will call the methods that calculates the coordinates and then passes it through the constructor,
        //to use our methods without objects our methods must be static

        public static Point NormalCoordinates(double a, double b)
        {
            return new Point(a, b);
        }
        public static Point PolarCoordinates(double a, double b)
        {
            return new Point(a * Math.Cos(b), b * Math.Sin(a));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var point = Point.PolarCoordinates(20, 30);
            Console.ReadLine();
        }
    }

}
