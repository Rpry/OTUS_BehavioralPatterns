using System.Collections.Generic;

namespace BehPatterns.Memento.DocumentStateSaving
{
    public sealed class History
    {
        private struct DocState
        {
            public List<string> Lines;
            public int CursorLine;
            public int CursorColumn;
            public string FontFamily;
            public int FontSize;
        }

        private readonly Stack<DocState> _undo = new Stack<DocState>();

        public int UndoCount => _undo.Count;
        public bool CanUndo => _undo.Count > 0;

        // Сохраняем состояние, копируя каждое поле вручную.
        // Ловушка 1: список надо копировать через new List<>(doc.Lines), иначе
        //            сохраним ссылку и последующие правки испортят «слепок».
        // Ловушка 2: новое поле в Document сюда не попадёт автоматически.
        public void Push(Document doc)
        {
            _undo.Push(new DocState
            {
                Lines = new List<string>(doc.Lines),
                CursorLine = doc.CursorLine,
                CursorColumn = doc.CursorColumn,
                FontFamily = doc.FontFamily,
                FontSize = doc.FontSize,
            });
        }

        public void Undo(Document doc)
        {
            if (_undo.Count == 0) return;
            var s = _undo.Pop();
            doc.Lines = new List<string>(s.Lines);
            doc.CursorLine = s.CursorLine;
            doc.CursorColumn = s.CursorColumn;
            doc.FontFamily = s.FontFamily;
            doc.FontSize = s.FontSize;
        }
    }
}
