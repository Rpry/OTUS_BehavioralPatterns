using System;

namespace BehPatterns.Command.BankAccountOperationsCommand
{
    // Receiver — получатель команд. Знает, как выполнять операции со счётом,
    // но ничего не знает про команды, историю и отмену.
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
}
