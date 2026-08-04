using System.Collections.Generic;

using BehPatterns.Mediator.Mediator;

namespace BehPatterns.Mediator.DomainServices.GetPostingExemplarRegradingRequirements
{
    public class GetPostingExemplarRegradingRequirementsQuery : IRequest<List<ExemplarRegradingRequirement>>
    {
        public string PostingReturnId;
    }
}
