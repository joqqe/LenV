namespace LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname
{
    public class UpdateCustomerFullnameCommandHandler : IRequestHandler<UpdateCustomerFullnameCommand>
    {
        private readonly ICustomerDbContext customerDbContext;

        public UpdateCustomerFullnameCommandHandler(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task<Unit> Handle(UpdateCustomerFullnameCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Fullname))
                throw new ArgumentException("Argument Fullname should not be null of emtpy!");

            var entity = await customerDbContext.Customers
                .FindAsync(new object[] { request.Id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            entity.FullName = request.Fullname;

            await customerDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
