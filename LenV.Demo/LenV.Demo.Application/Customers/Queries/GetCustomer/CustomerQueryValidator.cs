
namespace LenV.Demo.Application.Customers.Queries.GetCustomer
{
    public class CustomerQueryValidator : IRequestPreProcessor<CustomerQuery>
    {
        public Task Process(CustomerQuery request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
                throw new ArgumentOutOfRangeException("Id should be greater than 0.");

            return Task.CompletedTask;
        }
    }
}
