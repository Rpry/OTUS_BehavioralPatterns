using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.CheckCanPostingExemplarsMoveToReverseFlow
{
    public class CheckCanPostingExemplarsMoveToReverseFlowHandler : IRequestHandler<CheckCanPostingExemplarsMoveToReverseFlowQuery, ExemplarsReverseFlowCheck>
    {
        public Task<ExemplarsReverseFlowCheck> Handle(CheckCanPostingExemplarsMoveToReverseFlowQuery query)
        {
            Console.WriteLine($"  [handler] CheckCanPostingExemplarsMoveToReverseFlow: {query.PostingReturnId}, exemplars={query.ExemplarIds.Count}");
            var blocking = new List<string>();

            foreach (var id in query.ExemplarIds)
            {
                if (id == "ex-BAD") blocking.Add($"Экземпляр {id} уже в обратном потоке");
            }

            return Task.FromResult(new ExemplarsReverseFlowCheck { CanMove = blocking.Count == 0, BlockingReasons = blocking });
        }
    }
}
