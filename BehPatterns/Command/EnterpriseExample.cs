using System;
using System.Collections.Generic;

namespace BehPatterns.Command.Enterprise
{
    // === Интерфейс команды с поддержкой отмены ===

    public interface ICommand
    {
        void Execute();
        void Undo();
        string Description { get; }
    }

    // === Получатели (Receiver) ===

    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Пополнение {AccountNumber}: +{amount:C}. Баланс: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств");
            Balance -= amount;
            Console.WriteLine($"Снятие {AccountNumber}: -{amount:C}. Баланс: {Balance:C}");
        }

        public void Transfer(BankAccount to, decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств");
            Balance -= amount;
            to.Balance += amount;
            Console.WriteLine($"Перевод {AccountNumber} -> {to.AccountNumber}: {amount:C}");
        }
    }

    // === Конкретные команды ===

    public class DepositCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly decimal _amount;

        public string Description => $"Пополнение {_amount:C}";

        public DepositCommand(BankAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute() => _account.Deposit(_amount);
        public void Undo() => _account.Withdraw(_amount);
    }

    public class WithdrawCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly decimal _amount;

        public string Description => $"Снятие {_amount:C}";

        public WithdrawCommand(BankAccount account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute() => _account.Withdraw(_amount);
        public void Undo() => _account.Deposit(_amount);
    }

    public class TransferCommand : ICommand
    {
        private readonly BankAccount _from;
        private readonly BankAccount _to;
        private readonly decimal _amount;

        public string Description => $"Перевод {_amount:C}";

        public TransferCommand(BankAccount from, BankAccount to, decimal amount)
        {
            _from = from;
            _to = to;
            _amount = amount;
        }

        public void Execute() => _from.Transfer(_to, _amount);
        public void Undo() => _to.Transfer(_from, _amount); // Обратная операция
    }

    // === Макрокоманда ( несколько операций как одна ) ===

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
            Console.WriteLine($"\n=== Выполнение: {Description} ===");
            foreach (var cmd in _commands)
            {
                cmd.Execute();
            }
        }

        public void Undo()
        {
            Console.WriteLine($"\n=== Отмена: {Description} ===");
            // Отменяем в обратном порядке
            for (int i = _commands.Count - 1; i >= 0; i--)
            {
                _commands[i].Undo();
            }
        }
    }

    // === Invoker (History с поддержкой Undo/Redo) ===

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

    // === Клиентский код ===

    public class BankingDemo
    {
        public static void Run()
        {
            var account = new BankAccount("40702810000000000001", 10000m);
            var manager = new CommandManager();

            // Простые команды
            manager.ExecuteCommand(new DepositCommand(account, 5000m));
            manager.ExecuteCommand(new WithdrawCommand(account, 2000m));

            // Перевод между счетами
            var account2 = new BankAccount("40702810000000000002", 0);
            manager.ExecuteCommand(new TransferCommand(account, account2, 3000m));

            // Макрокоманда - зарплата (пополнение + снятие комиссии)
            var payroll = new CompositeCommand("Выплата зарплаты");
            payroll.AddCommand(new DepositCommand(account, 50000m));
            payroll.AddCommand(new WithdrawCommand(account, 1500m)); // комиссия
            manager.ExecuteCommand(payroll);

            // Показываем итоговый баланс
            Console.WriteLine($"\nИтоговый баланс {account.AccountNumber}: {account.Balance:C}");
            Console.WriteLine($"Итоговый баланс {account2.AccountNumber}: {account2.Balance:C}");

            // Демо отмены
            Console.WriteLine("\n--- Отмена последних операций ---");
            manager.Undo(); // отменяет макрокоманду
            manager.Undo(); // отменяет перевод

            Console.WriteLine($"\nПосле отмены:");
            Console.WriteLine($"Баланс {account.AccountNumber}: {account.Balance:C}");
            Console.WriteLine($"Баланс {account2.AccountNumber}: {account2.Balance:C}");

            // Повтор
            Console.WriteLine("\n--- Повтор отмененных ---");
            manager.Redo();

            Console.WriteLine($"\nПосле повтора:");
            Console.WriteLine($"Баланс {account.AccountNumber}: {account.Balance:C}");
        }
    }
}