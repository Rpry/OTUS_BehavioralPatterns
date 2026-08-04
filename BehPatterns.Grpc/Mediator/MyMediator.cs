using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehPatterns.Grpc.Mediator
{
    public class MyMediator : IMediator
    {
        private readonly Dictionary<Type, Func<object, Task<object>>> _handlers = new Dictionary<Type, Func<object, Task<object>>>();

        public void Register<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler)
            where TRequest : IRequest<TResponse>
        {
            // Лямбда захватывает handler (замыкание), чтобы делегат мог вызвать его
            // позже из Send, когда Register уже отработал. Приведение object → TRequest
            // безопасно: ключом служит typeof(TRequest), и Send ищет по тому же GetType().
            _handlers[typeof(TRequest)] = async req => await handler.Handle((TRequest)req);
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var reqType = request.GetType();

            if (!_handlers.TryGetValue(reqType, out var handler))
            {
                throw new InvalidOperationException($"Нет обработчика для запроса {reqType.Name}");
            }

            return (TResponse)await handler(request);
        }
    }
}
