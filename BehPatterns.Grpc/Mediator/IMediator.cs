using System.Threading.Tasks;

namespace BehPatterns.Grpc.Mediator
{
    // Медиатор: отправляет запрос нужному обработчику, не раскрывая его типа отправителю.
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
