using System;

namespace BehPatterns.Command.BankAccountOperations
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
}
