using System.Threading.Tasks;

namespace BehPatterns.Grpc.Mediator
{
    // Обработчик конкретного запроса: один запрос -> ровно один обработчик.
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
