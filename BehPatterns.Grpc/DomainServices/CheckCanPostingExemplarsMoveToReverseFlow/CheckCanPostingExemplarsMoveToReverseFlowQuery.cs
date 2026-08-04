using System.Collections.Generic;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.CheckCanPostingExemplarsMoveToReverseFlow
{
    public class CheckCanPostingExemplarsMoveToReverseFlowQuery : IRequest<ExemplarsReverseFlowCheck>
    {
        public string PostingReturnId;
        public List<string> ExemplarIds;
    }
}
