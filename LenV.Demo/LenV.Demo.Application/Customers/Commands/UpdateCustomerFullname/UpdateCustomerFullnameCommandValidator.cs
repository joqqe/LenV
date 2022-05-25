namespace LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname
{
    public class UpdateCustomerFullnameCommandValidator<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : UpdateCustomerFullnameCommand
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
                throw new ArgumentOutOfRangeException("Id should be greater than 0.");

            if (request.Fullname == null)
                throw new ArgumentNullException("Fullname should not be null.");

            if (request.Fullname == string.Empty)
                throw new ArgumentNullException("Fullname should not be empty.");

            return Task.CompletedTask;
        }
    }
}
