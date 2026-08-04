using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.GetPostingExemplarRegradingRequirements
{
    public class GetPostingExemplarRegradingRequirementsHandler : IRequestHandler<GetPostingExemplarRegradingRequirementsQuery, List<ExemplarRegradingRequirement>>
    {
        public Task<List<ExemplarRegradingRequirement>> Handle(GetPostingExemplarRegradingRequirementsQuery query)
        {
            Console.WriteLine($"  [handler] GetPostingExemplarRegradingRequirements: {query.PostingReturnId}");
            return Task.FromResult(new List<ExemplarRegradingRequirement>
            {
                new ExemplarRegradingRequirement { ExemplarId = "ex-001", CurrentSku = "SKU-A", RequiredSku = "SKU-B", Reason = "REGRADE" },
            });
        }
    }
}
