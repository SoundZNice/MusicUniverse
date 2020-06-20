using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Common.Behaviours
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _log;

        public LoggingBehavior(ILogger<TRequest> log)
        {
            _log = log;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _log.LogInformation($"Request received {typeof(TRequest).Name}");

            var response = await next();

            _log.LogInformation($"Answered with resopnse {typeof(TResponse).Name}");

            return response;
        }
    }
}
