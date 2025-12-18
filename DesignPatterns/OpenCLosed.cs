using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large, Yuge
    }
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Product(String name, Color color, Size size)
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
                {
                    yield return p;
                }
            }
        }
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }
        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                {
                    yield return p;
                }
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
    public class ColorSpecification : ISpecification<Product>
    {
        public Color Color { get; set; }
        public ColorSpecification(Color color)
        {
            Color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == Color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        public Size Size { get; set; }
        public SizeSpecification(Size size)
        {
            Size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == Size;
        }
    }
    public class AndSpecification : ISpecification<Product>
    {
        ISpecification<Product> First, Second;
        public AndSpecification(ISpecification<Product> first, ISpecification<Product> second)
        {
            First = first;
            Second = second;
        }
        public bool IsSatisfied(Product t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);

        }
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var p in items)
            {
                if (spec.IsSatisfied(p))
                {
                    yield return p;
                }
            }
        }
    }

    internal class ProgramOC
    {
        static void MainOC(string[] args)
        {
            var apple = new Product("Apple", Color.Red, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Yuge);

            Product[] products = new Product[] { apple, tree, house };

            //before
            Console.WriteLine("Before:");
            ProductFilter pf = new ProductFilter();
            Console.WriteLine("Red Products :");

            foreach (var p in pf.FilterByColor(products, Color.Red))
            {
                Console.WriteLine($" {p.Name} is Red");
            }
            //After
            Console.WriteLine("After :");
            var bf = new BetterFilter();
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Red)))
            /*
             bf.Filter(products,new ColorSpecification(Color.Red))) is valid because Color Specification Implements Ispecification, 
            think of it as below, so instead of interface we can pass like we did
             * ISpecification<Product> spec = new ColorSpecification(Color.Red);
             */
            {
                Console.WriteLine("Red Products :");
                Console.WriteLine($" {p.Name} is Red");
            }

            //And Filter
            foreach (var p in bf.Filter(products, new AndSpecification(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Yuge))))
            {
                Console.WriteLine("Blue and yuge Products :");
                Console.WriteLine($" {p.Name} is Blue and Yuge");
            }
        }
    }
}
