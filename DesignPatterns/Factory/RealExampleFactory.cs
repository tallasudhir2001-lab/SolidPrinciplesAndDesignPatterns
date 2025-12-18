using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public enum ServiceType
    {
        Email,
        Sms
    }
    public interface INotification
    {
        void Send(string message);
    }
    public class EmailNotificationService : INotification
    {
        public void Send(string message)
        {
            //
        }
    }
    public class SmsNotificationService : INotification
    {
        public void Send(string message)
        {
            //
        }
    }

    public class NotificationFactory
    {
        public INotification CreateServiceObject(ServiceType serviceType)
        {
            switch (serviceType)
            {
                case ServiceType.Email:
                    return new EmailNotificationService();
                case ServiceType.Sms:
                    return new SmsNotificationService();
                default:
                    return new EmailNotificationService();
            }
        }
    }
    internal class ProgramREF
    {
        static void MainREF(string[] args)
        {
            new NotificationFactory().CreateServiceObject(ServiceType.Email).Send("Sudhir");
            Console.ReadLine();
        }
    }

}
