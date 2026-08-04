using System.Collections.Generic;

using BehPatterns.Mediator.Mediator;

namespace BehPatterns.Mediator.DomainServices.CheckCanPostingExemplarsMoveToReverseFlow
{
    public class CheckCanPostingExemplarsMoveToReverseFlowQuery : IRequest<ExemplarsReverseFlowCheck>
    {
        public string PostingReturnId;
        public List<string> ExemplarIds;
    }
}
