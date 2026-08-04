using System.Collections.Generic;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.GetPostingExemplarRegradingRequirements
{
    public class GetPostingExemplarRegradingRequirementsQuery : IRequest<List<ExemplarRegradingRequirement>>
    {
        public string PostingReturnId;
    }
}
