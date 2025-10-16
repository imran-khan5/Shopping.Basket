using Shopping.Basket.Application.Abstractions;

namespace Shopping.Basket.Application.Mediator
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider _provider;

        public SimpleMediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken ct = default)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));
            var handler = _provider.GetService(handlerType)
                          ?? throw new InvalidOperationException($"Handler not registered: {handlerType}");

            return await ((dynamic)handler).Handle((dynamic)command, ct);
        }

        public async Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken ct = default)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
            var handler = _provider.GetService(handlerType)
                          ?? throw new InvalidOperationException($"Handler not registered: {handlerType}");

            return await ((dynamic)handler).Handle((dynamic)query, ct);
        }
    }
}
