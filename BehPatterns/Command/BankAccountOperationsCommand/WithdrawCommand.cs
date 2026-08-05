namespace BehPatterns.Command.BankAccountOperationsCommand
{
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
}
