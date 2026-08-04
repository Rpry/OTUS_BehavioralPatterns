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
            _handlers[typeof(TRequest)] = async req =>
            {
                var result = await handler.Handle((TRequest)req);
                return result;
            };
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
