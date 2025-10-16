namespace Shopping.Basket.Application.Abstractions;

public interface IMediatorBehavior
{
    Task<TResponse> Handle<TResponse>(object request, Func<Task<TResponse>> next, CancellationToken ct);
}