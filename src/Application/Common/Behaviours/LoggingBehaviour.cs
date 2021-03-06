using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BookCart.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            //TODO: Can log user info of every request here when authorization is enabled.

            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("BookCart Request: {Name} {@Request}",
                requestName, request);
        }
    }
}