using System;

namespace BehPatterns.Observer2
{
    public class NewsPublisher
    {
        public event Action<string> NewsArrived;

        public void AddNews(string news)
        {
            // Обработка новости...

            NewsArrived?.Invoke(news);
        }
    }

    public class Subscriber : IDisposable
    {
        private readonly NewsPublisher _newsPublisher;

        public Subscriber(NewsPublisher newsPublisher)
        {
            _newsPublisher = newsPublisher;
            _newsPublisher.NewsArrived += HandleNews;
        }

        public void Dispose()
        {
            _newsPublisher.NewsArrived -= HandleNews;
        }

        private void HandleNews(string news)
        {
            Console.WriteLine($"Пришла новость: {news}");
        }
    }
}
