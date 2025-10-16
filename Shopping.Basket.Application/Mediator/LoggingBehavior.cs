using Shopping.Basket.Application.Abstractions;
using Microsoft.Extensions.Logging;

namespace Shopping.Basket.Application.Mediator;

public class LoggingBehavior : IMediatorBehavior
{
    private readonly ILogger<LoggingBehavior> _logger;
    public LoggingBehavior(ILogger<LoggingBehavior> logger) => _logger = logger;

    public async Task<TResponse> Handle<TResponse>(object request, Func<Task<TResponse>> next, CancellationToken ct)
    {
        var name = request.GetType().Name;
        var start = DateTime.UtcNow;
        _logger.LogInformation("Handling {Name}", name);
        try
        {
            var resp = await next();
            var ms = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogInformation("Handled {Name} in {Elapsed} ms", name, ms);
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling {Name}", name);
            throw;
        }
    }
}