using System;
using System.Collections.Generic;
using System.Linq;

namespace BehPatterns.Memento.DocumentStateSavingWithMemento
{
    public sealed class Document
    {
        public string Id { get; } = Guid.NewGuid().ToString("N");

        private readonly List<string> _lines = new List<string>();
        private int _cursorLine;
        private int _cursorColumn;
        private string _fontFamily = "Inter";
        private int _fontSize = 14;

        public IReadOnlyList<string> Lines => _lines;
        public (int Line, int Column) Cursor => (_cursorLine, _cursorColumn);
        public string FontFamily => _fontFamily;
        public int FontSize => _fontSize;

        public void SetText(string text)
        {
            _lines.Clear();
            if (!string.IsNullOrEmpty(text))
                _lines.AddRange(text.Split('\n'));
            ClampCursor();
        }

        public void AppendLine(string line)
        {
            _lines.Add(line);
            _cursorLine = _lines.Count - 1;
            _cursorColumn = (_lines.Count > 0 ? _lines[^1].Length : 0);
        }

        public void MoveCursor(int line, int column)
        {
            _cursorLine = line;
            _cursorColumn = column;
            ClampCursor();
        }

        public void SetFont(string family, int size)
        {
            _fontFamily = family;
            _fontSize = size;
        }

        private void ClampCursor()
        {
            _cursorLine = Math.Clamp(_cursorLine, 0, Math.Max(0, _lines.Count - 1));
            var current = _lines.Count > 0 ? _lines[_cursorLine] : string.Empty;
            _cursorColumn = Math.Clamp(_cursorColumn, 0, current.Length);
        }

        // --- Memento ---
        public sealed class Snapshot : IMemento<DocumentState>
        {
            public string OriginatorId { get; }
            public DateTime CreatedAt { get; }
            public long SizeBytes { get; }

            private readonly DocumentState _state;

            internal Snapshot(string originatorId, DocumentState state)
            {
                OriginatorId = originatorId;
                CreatedAt = DateTime.UtcNow;
                _state = state;
                SizeBytes = state.Lines.Sum(l => l.Length * sizeof(char)) + 64;
            }

            public DocumentState GetState() => _state.Clone();
        }

        public sealed class DocumentState
        {
            public List<string> Lines { get; init; }
            public int CursorLine { get; init; }
            public int CursorColumn { get; init; }
            public string FontFamily { get; init; }
            public int FontSize { get; init; }

            public DocumentState Clone() => new DocumentState()
            {
                Lines = Lines is null ? new List<string>() : new List<string>(Lines),
                CursorLine = CursorLine,
                CursorColumn = CursorColumn,
                FontFamily = FontFamily,
                FontSize = FontSize,
            };
        }

        public Snapshot SaveSnapshot()
        {
            var state = new DocumentState
            {
                Lines = new List<string>(_lines),
                CursorLine = _cursorLine,
                CursorColumn = _cursorColumn,
                FontFamily = _fontFamily,
                FontSize = _fontSize,
            };
            return new Snapshot(Id, state);
        }

        public void Restore(Snapshot snapshot)
        {
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            if (snapshot.OriginatorId != Id)
                throw new InvalidOperationException("Снимок принадлежит другому документу");

            var state = snapshot.GetState();
            _lines.Clear();
            _lines.AddRange(state.Lines);
            _cursorLine = state.CursorLine;
            _cursorColumn = state.CursorColumn;
            _fontFamily = state.FontFamily;
            _fontSize = state.FontSize;
            ClampCursor();
        }

        public override string ToString()
            => $"lines={String.Join(',', _lines)}, cursor=({_cursorLine},{_cursorColumn}), font={_fontFamily}/{_fontSize}";
    }
}
