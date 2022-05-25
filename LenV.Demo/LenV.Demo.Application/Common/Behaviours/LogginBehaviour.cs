namespace LenV.Demo.Application.Common.Behaviours
{
    public class LogginBehaviour<TRequest> : IRequestPreProcessor<TRequest> 
        where TRequest : notnull
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Request: {request.GetType().Name}");

            return Task.CompletedTask;
        }
    }
}
