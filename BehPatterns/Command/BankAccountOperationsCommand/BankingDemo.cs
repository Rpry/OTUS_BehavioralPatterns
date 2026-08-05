using System;

namespace BehPatterns.Command.BankAccountOperationsCommand
{
    // Client — собирает ресивер, команды и инвокер вместе.
    public class BankingDemo
    {
        public static void Run()
        {
            var account = new BankAccount("40702810000000000001", 10000m);
            var manager = new CommandManager();

            // Простые команды
            manager.ExecuteCommand(new DepositCommand(account, 5000m));
            manager.ExecuteCommand(new WithdrawCommand(account, 2000m));

            // Демо отмены
            Console.WriteLine("\n--- Отмена последних операций ---");
            manager.Undo(); // отменяет макрокоманду
            manager.Undo(); // отменяет перевод

            Console.WriteLine($"\nПосле отмены:");
            Console.WriteLine($"Баланс {account.AccountNumber}: {account.Balance:C}");

            // Повтор
            Console.WriteLine("\n--- Повтор отмененных ---");
            manager.Redo();

            Console.WriteLine($"\nПосле повтора:");
            Console.WriteLine($"Баланс {account.AccountNumber}: {account.Balance:C}");

            /*
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
            */
        }
    }
}
