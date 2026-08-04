using System.Collections.Generic;

using BehPatterns.Mediator.Mediator;

namespace BehPatterns.Mediator.DomainServices.GetPostingReturnOperations
{
    public class GetPostingReturnOperationsQuery : IRequest<List<PostingReturnOperation>>
    {
        public string PostingReturnId;
    }
}
