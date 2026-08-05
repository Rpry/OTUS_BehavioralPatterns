namespace BehPatterns.Command.BankAccountOperationsCommand
{
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
}
