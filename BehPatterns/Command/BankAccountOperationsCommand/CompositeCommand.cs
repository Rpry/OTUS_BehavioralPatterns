using System.Collections.Generic;

namespace BehPatterns.Command.BankAccountOperationsCommand
{
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public string Description { get; }

        public CompositeCommand(string description)
        {
            Description = description;
        }

        public void AddCommand(ICommand command) => _commands.Add(command);

        public void Execute()
        {
            System.Console.WriteLine($"\n=== Выполнение: {Description} ===");
            foreach (var cmd in _commands)
            {
                cmd.Execute();
            }
        }

        public void Undo()
        {
            System.Console.WriteLine($"\n=== Отмена: {Description} ===");
            // Отменяем в обратном порядке
            for (int i = _commands.Count - 1; i >= 0; i--)
            {
                _commands[i].Undo();
            }
        }
    }
}
