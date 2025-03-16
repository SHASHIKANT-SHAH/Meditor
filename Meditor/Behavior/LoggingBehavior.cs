using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Meditor.Behavior
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation($"Handling TRequest {typeof(TRequest).Name}");
                var response = await next();
                _logger.LogInformation($"Handled TResponse {typeof(TResponse).Name}");
                return response;
            }
            catch (Exception ex)
            {
                // Log the error when it occurs
                _logger.LogError(ex, $"An error occurred while handling {typeof(TRequest).Name}");
                throw;  // Re-throw the exception to ensure it propagates
            }
        }
    }

}
