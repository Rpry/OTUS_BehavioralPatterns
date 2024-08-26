using System;
using System.Collections.Generic;

namespace BehPatterns.Observer2
{
    public class NewsPublisher
    {
        private readonly List<string> _news = new List<string>();
        public event Action<string> NewsArrived;

        public void AddNews(string news)
        {
            _news.Add(news);
            NewsArrived?.Invoke(news);
        }
    }

    public class Person : IDisposable
    {
        private readonly NewsPublisher _newsPublisher;

        public Person(NewsPublisher newsPublisher)
        {
            _newsPublisher = newsPublisher;
            _newsPublisher.NewsArrived += HandleNews;
        }

        public void Dispose()
        {
            _newsPublisher.NewsArrived -= HandleNews;
        }

        public void HandleNews(string news)
        {
            Console.WriteLine($"Пришла новость {news}");
        }
    }
}
