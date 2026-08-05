using System;
using System.Collections.Generic;

namespace BehPatterns.Memento.DocumentStateSavingWithMemento
{
    // Caretaker — хранитель истории снимков.
    public sealed class History
    {
        private readonly Stack<IMemento> _undo = new Stack<IMemento>();

        public History(int maxEntries = 100)
        {
            if (maxEntries <= 0) throw new ArgumentOutOfRangeException(nameof(maxEntries));
        }

        public int UndoCount => _undo.Count;
        public bool CanUndo => _undo.Count > 0;

        // Записать снимок в историю.
        public void Push(IMemento memento)
        {
            _undo.Push(memento);
        }

        public void Undo(Action<IMemento> restore)
        {
            if (!CanUndo) throw new InvalidOperationException("Откатывать нечего");
            restore(_undo.Pop());
        }
    }
}
