using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //class NotificationService
    //{
    //    EmailService emailService = new EmailService();
    //    // here NotificationService service is tightky coupled with email service
    //    //if in future we want to change to sms service , we need to replace above object with SmsService.

    //    public void Send(String message)
    //    {
    //        emailService.SendEmal(message);
    //    }
    //}
    //public class EmailService
    //{
    //    public void SendEmal(String message)
    //    {
    //        //email 
    //    }
    //}
    public interface INotifier
    {
        void Send(string message);
    }
    public class EmailService : INotifier
    {
        public void Send(string message)
        {
            //
        }
    }
    public class SmsService : INotifier
    {
        public void Send(string message)
        {
            //
        }
    }
    public class NotificationService
    {
        public readonly INotifier _notifier;
        public NotificationService(INotifier notifier)
        {
            _notifier = notifier;
        }
        public void Send(string message)
        {
            _notifier.Send(message);
        }
    }
    internal class ProgramII
    {
        static void MainII(string[] args)
        {
            var notificationServie = new NotificationService(new SmsService());
            notificationServie.Send("Hello Sudhir");
        }
    }
}
