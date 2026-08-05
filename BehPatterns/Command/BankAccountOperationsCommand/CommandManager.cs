using System;
using System.Collections.Generic;

namespace BehPatterns.Command.BankAccountOperationsCommand
{
    // Invoker — вызывающая сторона. Знает, когда вызывать команду и как вести
    // историю undo/redo, но не знает, что именно делает команда.
    public class CommandManager
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();   // выполненные
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>(); // отмененные

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
            _redoStack.Clear(); // после новой команды redo очищается
            Console.WriteLine($"[История] Добавлено: {command.Description}");
        }

        public void Undo()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("Нечего отменять");
                return;
            }

            var command = _history.Pop();
            command.Undo();
            _redoStack.Push(command);
            Console.WriteLine($"[Отмена] {command.Description}");
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
            {
                Console.WriteLine("Нечего повторить");
                return;
            }

            var command = _redoStack.Pop();
            command.Execute();
            _history.Push(command);
            Console.WriteLine($"[Повтор] {command.Description}");
        }

        public void ShowHistory()
        {
            Console.WriteLine("\n--- История операций ---");
            foreach (var cmd in _history)
            {
                Console.WriteLine($"  - {cmd.Description}");
            }
        }
    }
}
