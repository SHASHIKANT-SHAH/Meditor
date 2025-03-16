using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meditor.Behavior
{
    public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CacheBehavior<TRequest, TResponse>> _logger;

        public CacheBehavior(IMemoryCache cache, ILogger<CacheBehavior<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cacheKey = request.GetHashCode().ToString();

            try
            {
                if (_cache.TryGetValue(cacheKey, out TResponse response))
                {
                    _logger.LogInformation($"Returning cached response for {typeof(TRequest).Name}");
                    return response;
                }

                _logger.LogInformation($"Cache miss for {typeof(TRequest).Name}. Invoking handler.");
                response = await next();

                // Cache the response with an expiration time of 5 minutes
                _cache.Set(cacheKey, response, TimeSpan.FromMinutes(1));

                return response;
            }
            catch (Exception ex)
            {
                // Log the error in case of any exception (e.g., cache retrieval issues)
                _logger.LogError(ex, $"An error occurred while handling cache for {typeof(TRequest).Name}");
                throw;  // Re-throw the exception to propagate it
            }
        }

    }

}
