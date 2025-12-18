using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPlusFactory
{
    public enum Services
    {
        Sms, Email
    }

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
    public class NotificationFactory
    {
        public InotificationService CreateObject(Services servicetype)
        {
            switch (servicetype)
            {
                case Services.Sms:
                    return new SMSService();
                case Services.Email:
                    return new EMailService();
                default:
                    throw new NotImplementedException();
            }
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


    internal class ProgramSPF
    {
        static void MainSPF(string[] args)
        {
            //let's say we are getting sms and email from frontend , 
            //in backend we need to iterate those two enums and retrive the object and set the strategy object for it.send mails
            //I have created a Factory to retrive object based in enums
            NotificationContext context = new NotificationContext();
            List<Services> services = new List<Services> { Services.Sms, Services.Email };
            foreach (Services service in services)
            {
                context.SetStrategy(new NotificationFactory().CreateObject(service));
                context.Send("Hi Sudhir");
            }
        }
    }
}
