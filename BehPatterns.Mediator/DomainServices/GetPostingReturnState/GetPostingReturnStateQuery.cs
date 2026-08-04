using BehPatterns.Mediator.Mediator;

namespace BehPatterns.Mediator.DomainServices.GetPostingReturnState
{
    // Запросы/команды (IRequest) — сообщения, которыми оперирует медиатор.
    // Имя аргумента = имя метода gRPC-контроллера + "Query".

    public class GetPostingReturnStateQuery : IRequest<PostingReturnState>
    {
        public string PostingReturnId;
    }
}
