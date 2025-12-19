using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    //this is our application - defined interface
    public interface ILogger
    {
        void Log(string message);
        void LogError(string errorMessage);
    }
    //let's say we have a 3rd party logger NLog and assume it's a legacy, So it has lagacy namings back then,
    //But in our application we use proper names as Adapters localize ugliness 😄Legacy code can be:Ugly, Inconsistent, Badly named
    //third party one
    public class NLogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
        public void LogErrorDetails(string errorDetails)
        {
            Console.WriteLine(errorDetails);
        }
    }
    //Adapter Implementation to connect our Logger to Thirdparty keeping our interface name as it is
    public class LoggerAdapter : ILogger
    {
        public NLogger logger;
        public LoggerAdapter(NLogger logger)
        {
            this.logger = logger;
        }
        public void Log(string message)
        {
            logger.LogInfo(message);
        }
        public void LogError(string errorMessage)
        {
            logger.LogErrorDetails(errorMessage);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new LoggerAdapter(new NLogger());
            logger.Log("Hi Sudhir");
            logger.LogError("I am Error");
            Console.Read();
        }
    }
}
