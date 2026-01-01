using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DecoratorPattern
{
    public interface ICoffee
    {
        double GetCost();
        String GetDescription();
    }
    public class SimpleCoffee : ICoffee
    {
        public double GetCost()
        {
            return 20;
        }

        public string GetDescription()
        {
            return "Simple Coffee";
        }
    }
    public class Espresso : ICoffee
    {
        public double GetCost()
        {
            return 30;
        }

        public string GetDescription()
        {
            return "Espresso";
        }
    }
    /*
     * this must be abstract as we cannot create objects for abstract classes 
     * We should not be able to create object here because it is used as a wrapper from sugar and milk for coffe
     * we cannot just order sugar or milk without a coffee
        */
    public abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee;
        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public virtual double GetCost()
        {
            return _coffee.GetCost();
        }
        public virtual String GetDescription()
        {
            return _coffee.GetDescription();
        }
    }
    public class MilkDecorator : CoffeeDecorator
    {
        //this tells first create the base object and then child using coffee object
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {

        }
        public override double GetCost()
        {
            return _coffee.GetCost() + 5;
        }
        public override string GetDescription()
        {
            return _coffee.GetDescription() + "Milk";
        }
    }
    public class SugarDecorator : CoffeeDecorator
    {
        //this tells first create the base object and then child using coffee object
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {

        }
        public override double GetCost()
        {
            return _coffee.GetCost() + 5;
        }
        public override string GetDescription()
        {
            return _coffee.GetDescription() + "Sugar";
        }
    }

    internal class ProgramD
    {
        static void MainD(string[] args)
        {
            ICoffee coffee = new SugarDecorator(
                                 new MilkDecorator(
                                    new SimpleCoffee()));
            Console.WriteLine(coffee.GetCost());
            Console.Read();
        }
    }
}
/*
 * Intergration With Frontend
 * below is sent from UI to backend
 * 
 * {
  "coffeeType": "Simple",
  "addons": ["Milk", "Sugar"]
    }
    
ICoffee coffee = request.CoffeeType switch
{
    "Simple" => new SimpleCoffee(),
    "Espresso" => new Espresso(),
    _ => throw new Exception("Invalid coffee type")
};

foreach (var addon in request.AddOns)
{
    coffee = addon switch
    {
        "Milk"  => new MilkDecorator(coffee),
        "Sugar" => new SugarDecorator(coffee),
        _ => coffee
    };
}
 */