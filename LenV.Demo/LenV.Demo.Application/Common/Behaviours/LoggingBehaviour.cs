using System.Diagnostics;
using System.Text.Json;

namespace LenV.Demo.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var id = Guid.NewGuid().ToString();
            var name = request.GetType().Name;
            var requestAsString = JsonSerializer.Serialize(request);

            Console.WriteLine($"Begin Request Id:{id}, Request name:{name}, Request content:{requestAsString}");
            
            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            
            Console.WriteLine($"End Request Id:{id}, Request name:{name}, Request content:{requestAsString}, Total request time:{timer.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
