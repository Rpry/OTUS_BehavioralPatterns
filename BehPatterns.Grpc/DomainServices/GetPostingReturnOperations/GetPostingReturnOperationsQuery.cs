using System.Collections.Generic;

using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.GetPostingReturnOperations
{
    public class GetPostingReturnOperationsQuery : IRequest<List<PostingReturnOperation>>
    {
        public string PostingReturnId;
    }
}
