using System;
using System.Threading.Tasks;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.GetPostingReturnState
{
    public class GetPostingReturnStateHandler : IRequestHandler<GetPostingReturnStateQuery, PostingReturnState>
    {
        public Task<PostingReturnState> Handle(GetPostingReturnStateQuery query)
        {
            Console.WriteLine($"  [handler] GetPostingReturnState: {query.PostingReturnId}");
            return Task.FromResult(new PostingReturnState
            {
                PostingReturnId = query.PostingReturnId,
                Status = "IN_PROGRESS",
                Reason = "DEFECT",
                CreatedAt = "2026-08-01T10:00:00Z"
            });
        }
    }
}
