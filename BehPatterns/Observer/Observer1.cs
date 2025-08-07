using System;
using System.Collections.Generic;

namespace BehPatterns.Observer1
{
    public class NewsPublisher
    {
        private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void AddNews(string news)
        {
            // Обработка новости...
            
            foreach(ISubscriber subscriber in _subscribers)
            {
                subscriber.HandleNews(news);
            }
        }

        public void SubscribeMe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void UnsubscribeMe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }

    public interface ISubscriber
    {
        public void HandleNews(string news);
    }

    public class Subscriber : ISubscriber, IDisposable
    {
        private readonly NewsPublisher _newsPublisher;

        public Subscriber(NewsPublisher newsPublisher)
        {
            _newsPublisher = newsPublisher;
            _newsPublisher.SubscribeMe(this);
        }

        public void Dispose()
        {
            _newsPublisher.UnsubscribeMe(this);
        }

        public void HandleNews(string news)
        {
            Console.WriteLine($"Пришла новость: {news}");
        }
    }
}
