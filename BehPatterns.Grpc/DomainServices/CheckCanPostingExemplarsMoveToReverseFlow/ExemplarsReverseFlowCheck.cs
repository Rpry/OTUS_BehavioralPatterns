using System.Collections.Generic;

namespace BehPatterns.Grpc.DomainServices.CheckCanPostingExemplarsMoveToReverseFlow
{
    // Результат проверки возможности перевода экземпляров в обратный поток.
    public class ExemplarsReverseFlowCheck
    {
        public bool CanMove;
        public List<string> BlockingReasons;
    }
}
