using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public interface InotificationService
    {
        void Send(string message);
    }
    public class SMSService : InotificationService
    {
        public void Send(string message)
        {
        }
    }
    public class EMailService : InotificationService
    {
        public void Send(string message)
        {
        }
    }
    public class NotificationContext
    {
        InotificationService inotificationService;
        //can't use constructor because will need to assign different object later
        public void SetStrategy(InotificationService inotificationService)
        {
            this.inotificationService = inotificationService;
        }
        public void Send(string message)
        {
            inotificationService.Send(message);
        }
    }


    internal class ProgramS
    {
        static void MainS(string[] args)
        {
            NotificationContext notificationContext = new NotificationContext();
            notificationContext.SetStrategy(new SMSService());
            notificationContext.Send("Hi Sudhir");

            //assigning a different strategy at run time
            notificationContext.SetStrategy(new EMailService());
            notificationContext.Send("Hi Sudhir");
            Console.ReadLine();
        }
    }
}
