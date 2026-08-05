using System;

namespace BehPatterns.Memento.DocumentStateSavingWithMemento
{
    public static class MementoDemo
    {
        public static void Run()
        {
            var doc = new Document();
            var history = new History(maxEntries: 5);

            doc.SetText("Первая правка");
            history.Push(doc.SaveSnapshot());
            Print(doc);

            doc.SetText("Вторая правка");
            history.Push(doc.SaveSnapshot());
            Print(doc);

            Undo(doc, history);
            Print(doc);
        }

        private static void Undo(Document doc, History history)
        {
            history.Undo(m => doc.Restore((Document.Snapshot)m));
            Console.WriteLine("  undo");
        }

        private static void Print(Document doc) => Console.WriteLine($"  doc: {doc}");
    }
}
