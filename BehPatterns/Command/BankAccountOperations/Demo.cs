namespace BehPatterns.Command.BankAccountOperations
{
    public class Demo
    {
        public static void Run()
        {
            var account = new BankAccount("40702810000000000001", 10000m);
            var delegateManager = new CommandManagerDelegate();
            delegateManager.ExecuteAction(() => account.Deposit(5000m));
            delegateManager.ExecuteAction(() => account.Withdraw(2000m));
        }
    }
}
