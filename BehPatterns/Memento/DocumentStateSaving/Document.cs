using System;
using System.Collections.Generic;

namespace BehPatterns.Memento.DocumentStateSaving
{
    public sealed class Document
    {
        private List<string> _lines = new List<string>();
        private int _cursorLine;
        private int _cursorColumn;
        private string _fontFamily = "Inter";
        private int _fontSize = 14;

        public List<string> Lines
        {
            get => _lines;
            set => _lines = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int CursorLine
        {
            get => _cursorLine;
            set => _cursorLine = Math.Clamp(value, 0, Math.Max(0, _lines.Count - 1));
        }

        public int CursorColumn
        {
            get => _cursorColumn;
            set => _cursorColumn = Math.Clamp(value, 0, CurrentLineLength);
        }

        public string FontFamily
        {
            get => _fontFamily;
            set => _fontFamily = string.IsNullOrEmpty(value)
                ? throw new ArgumentException("Шрифт должен быть задан", nameof(value))
                : value;
        }

        public int FontSize
        {
            get => _fontSize;
            set => _fontSize = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Размер шрифта должен быть положительным");
        }

        private int CurrentLineLength => _lines.Count > 0 ? _lines[_cursorLine].Length : 0;

        public void SetText(string text)
        {
            Lines = new List<string>();
            if (!string.IsNullOrEmpty(text))
                Lines.AddRange(text.Split('\n'));
        }

        public void AppendLine(string line) => Lines.Add(line);

        public void MoveCursor(int line, int column)
        {
            CursorLine = line;
            CursorColumn = column;
        }

        public void SetFont(string family, int size)
        {
            FontFamily = family;
            FontSize = size;
        }

        public override string ToString()
            => $"lines={String.Join(',', Lines)}, cursor=({CursorLine},{CursorColumn}), font={FontFamily}/{FontSize}";
    }
}
