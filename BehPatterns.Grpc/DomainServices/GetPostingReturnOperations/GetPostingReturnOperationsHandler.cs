using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.GetPostingReturnOperations
{
    public class GetPostingReturnOperationsHandler : IRequestHandler<GetPostingReturnOperationsQuery, List<PostingReturnOperation>>
    {
        public Task<List<PostingReturnOperation>> Handle(GetPostingReturnOperationsQuery query)
        {
            Console.WriteLine($"  [handler] GetPostingReturnOperations: {query.PostingReturnId}");
            return Task.FromResult(new List<PostingReturnOperation>
            {
                new PostingReturnOperation { OperationId = "op-1", PostingReturnId = query.PostingReturnId, Type = "PICKUP", Status = "DONE", PerformedAt = "2026-08-01T10:05:00Z" },
                new PostingReturnOperation { OperationId = "op-2", PostingReturnId = query.PostingReturnId, Type = "INSPECT", Status = "PENDING", PerformedAt = "2026-08-01T10:30:00Z" },
            });
        }
    }
}
