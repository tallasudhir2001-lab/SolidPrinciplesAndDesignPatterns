using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    /*
      Singleton ensures that a class has only ONE instance and provides a global access point to it.

        In simple words:

        You cannot create multiple objects

        Everyone in the app uses the same instance
    */

    //public class Singleton
    //{
    //    public static Singleton Instance;
    //    //constructor is private so no one can create objects
    //    private Singleton()
    //    {
    //    }

    //        //using the static method Singleton object is created
    //        //If two threads enter at the same time two instances, not safe in real life apps
    //    public static Singleton CreateObject
    //    {
    //        get
    //        {
    //            if(Instance == null)
    //                Instance=new Singleton();
    //            return Instance;
    //        }
    //    }
    //}
    public class Singleton
    {
        public static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        private Singleton()
        {

        }
        public static Singleton Instance => _instance.Value;
    }
    internal class ProgramS
    {
        static void MainS(string[] args)
        {
            Console.ReadLine();
        }
    }
}
