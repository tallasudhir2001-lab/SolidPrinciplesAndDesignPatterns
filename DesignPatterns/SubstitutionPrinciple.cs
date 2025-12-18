using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Rectangle
    {
        //public int width { get; set; }
        //public int height { get; set; }

        public virtual int width { get; set; }
        public virtual int height { get; set; }
        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
    public class Square : Rectangle
    {
        public override int width { set => base.width = base.height = value; }
        public override int height { set => base.width = base.height = value; }
    }
    internal class ProgramSP
    {
        static public int Area(Rectangle r)
        {
            return r.width * r.height;
        }
        static void MainSP(string[] args)
        {
            //Rectangle r=new Rectangle(2,4);
            //Console.WriteLine($"Area is {Area(r)}");
            //Console.Read();

            //also works fine
            //Square square = new Square();

            //since we use new in Square It points to Refernece type which is Rectangle
            //left side is reference type , right side is object type
            //so now it points to Rectangle
            //Rectangle r = new Square();
            //r.width = 10;
            //Console.WriteLine($"Area is {Area(r)}");
            //Console.Read();

            //if we use Virtual and override the object points to object type which is on the right hand side
            Rectangle r = new Square();
            r.width = 10;
            Console.WriteLine($"Area is {Area(r)}");
            Console.Read();
        }
    }
}
