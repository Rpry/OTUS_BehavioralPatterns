using System;

namespace BehPatterns.Memento.DocumentStateSaving
{
    public static class Demo
    {
        public static void Run()
        {
            var doc = new Document();
            var history = new History();

            history.Push(doc);
            doc.SetText("Первая правка");
            Print(doc);
            history.Push(doc);
            doc.SetText("Вторая правка");
            Print(doc);
            history.Push(doc);
            doc.SetText("И третья правка");
            Print(doc);

            Console.WriteLine("\n--- Undo ---");
            history.Undo(doc);
            Print(doc);
            Console.WriteLine("\n--- Undo ---");
            history.Undo(doc);
            Print(doc);
        }

        private static void Print(Document doc) => Console.WriteLine($"  doc: {doc}");
    }
}
