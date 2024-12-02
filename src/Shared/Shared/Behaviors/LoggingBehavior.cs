using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Shared.Behaviors;

public class LoggingBehavior<TRequst, TResponse>
    (ILogger<LoggingBehavior<TRequst, TResponse>> logger)
    : IPipelineBehavior<TRequst, TResponse>
    where TRequst : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequst request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation
            ("[Start] Handle request={Request} - Response={Respose} - RequestData={RequestData}",
            typeof(TRequst).Name, typeof(TRequst).Name, request);

        var startTime = Stopwatch.GetTimestamp();
        var response = await next();
        var deltatime = Stopwatch.GetElapsedTime(startTime);

        if (deltatime.TotalSeconds > 3)
        {
            logger.LogWarning
                ("[PREFORMANCE] Long execution time for {Request} - {ElapsedMilliseconds}ms - RequestData={RequestData}", typeof(TRequst).Name, deltatime.TotalMilliseconds, request);
        }

        logger.LogInformation("[End] Handle request={Request} - Response={Respose} - RequestData={RequestData}",
            typeof(TRequst).Name, typeof(TRequst).Name, request);

        return response;
    }
}
