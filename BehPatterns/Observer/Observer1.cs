using System;
using System.Collections.Generic;

namespace BehPatterns.Observer1
{
    public class NewsPublisher
    {
        private readonly List<string> _news = new List<string>();
        private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void AddNews(string news)
        {
            _news.Add(news);
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

    public class Person : ISubscriber, IDisposable
    {
        private readonly NewsPublisher _newsPublisher;

        public Person(NewsPublisher newsPublisher)
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
            Console.WriteLine($"Пришла новость {news}");
        }
    }
}
