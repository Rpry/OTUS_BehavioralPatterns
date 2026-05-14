using System;
using System.Collections.Generic;

namespace BehPatterns.Command.DelegateExample
{
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
    }

    public class CommandManagerDelegate
    {
        private readonly List<Action> _executedActions = new List<Action>();

        public void ExecuteAction(Action action)
        {
            action();
            _executedActions.Add(action);
            Console.WriteLine($"[История] Добавлено действие");
        }
    }

    public class DelegateDemo
    {
        public static void Run()
        {
            var account = new BankAccount("40702810000000000001", 10000m);

            Console.WriteLine("=== Вариант 1: Простой delegate (без Undo) ===");
            var delegateManager = new CommandManagerDelegate();
            delegateManager.ExecuteAction(() => account.Deposit(5000m));
            delegateManager.ExecuteAction(() => account.Withdraw(2000m));
        }
    }
}