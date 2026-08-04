using System.Collections.Generic;
using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.Domain
{
    // Запросы/команды (IRequest) — сообщения, которыми оперирует медиатор.
    // Имена аргументов = имя метода gRPC-контроллера + "Query".

    public class GetPostingReturnStateQuery : IRequest<PostingReturnState>
    {
        public string PostingReturnId;
    }

    public class GetPostingReturnOperationsQuery : IRequest<List<PostingReturnOperation>>
    {
        public string PostingReturnId;
    }

    public class GetPostingExemplarRegradingRequirementsQuery : IRequest<List<ExemplarRegradingRequirement>>
    {
        public string PostingReturnId;
    }

    public class CheckCanPostingExemplarsMoveToReverseFlowQuery : IRequest<ExemplarsReverseFlowCheck>
    {
        public string PostingReturnId;
        public List<string> ExemplarIds;
    }
}
