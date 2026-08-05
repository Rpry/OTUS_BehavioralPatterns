using System;
using System.Collections.Generic;

namespace BehPatterns.Command.BankAccountOperations
{
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
}
