using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ObserverWithDBContext
{
    public interface ISubscriber//observer
    {
        void Update(String ChannelName, String VideoTitle);
    }
    public interface IYouTubeChannel
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void UploadVideo(String VideoTitle);
        void NotifySubscribers();
    }
    public class YouTubeChannel : IYouTubeChannel
    {
        public String ChannelName { get; set; }
        public String VideoTitle { get; set; }
        public List<ISubscriber> subscribers = new List<ISubscriber>();
        //public List<ISubscriber> subscribers = new(); both are same
        public YouTubeChannel(String ChannelName)
        {
            this.ChannelName = ChannelName;
        }

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }
        public void UploadVideo(string VideoTitle)
        {
            this.VideoTitle = VideoTitle;
            NotifySubscribers();
        }
        public void NotifySubscribers()
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(ChannelName, VideoTitle);
            }
        }
    }
    //We still need uSerSubscriber even if users exists in database,
    //If we use EF, We need to do like this
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserSubscriber : ISubscriber
    {
        public UserEntity user;
        public UserSubscriber(UserEntity user)
        {
            this.user = user;
        }

        public void Update(string ChannelName, string VideoTitle)
        {
            Console.WriteLine(user.Email + " Got Notified");
        }
    }
    internal class ProgramOD
    {
        static void MainOD(string[] args)
        {
            var channel = new YouTubeChannel("Sudhir Goud");
            //var user1 = new UserSubscriber("Sudhir");
            //var user2 = new UserSubscriber("bang");

            /*
            List<UserEntity> usersFromDb = userRepository.GetSubscribers(channelId);

            foreach (var user in usersFromDb)
            {
                channel.Subscribe(new UserSubscriber(user));
            }

            channel.Subscribe(user1);
            channel.Subscribe(user2);
            channel.UploadVideo("new video");
            */
            Console.Read();
        }
    }
}
