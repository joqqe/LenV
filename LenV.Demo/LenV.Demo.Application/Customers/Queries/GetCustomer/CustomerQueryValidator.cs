
namespace LenV.Demo.Application.Customers.Queries.GetCustomer
{
    public class CustomerQueryValidator<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : CustomerQuery
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
                throw new ArgumentOutOfRangeException("Id should be greater than 0.");

            return Task.CompletedTask;
        }
    }
}
