namespace BehPatterns.Command.BankAccountOperations
{
    public class DirectDemo
    {
        public static void Run()
        {
            var account = new BankAccount("40702810000000000001", 10000m);
            account.Deposit(5000m);
            account.Withdraw(2000m);
        }
    }
}
