using BehPatterns.Grpc.Mediator;

namespace BehPatterns.Grpc.DomainServices.GetPostingReturnState
{
    // Запросы/команды (IRequest) — сообщения, которыми оперирует медиатор.
    // Имя аргумента = имя метода gRPC-контроллера + "Query".

    public class GetPostingReturnStateQuery : IRequest<PostingReturnState>
    {
        public string PostingReturnId;
    }
}
