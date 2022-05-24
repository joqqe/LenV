namespace LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname
{
    public class UpdateCustomerFullnameCommandHandler : ICommandHandler<UpdateCustomerFullnameCommand>
    {
        private readonly ICustomerDbContext customerDbContext;

        public UpdateCustomerFullnameCommandHandler(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task Execute(UpdateCustomerFullnameCommand request, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(request.Fullname))
                throw new ArgumentException("Argument Fullname should not be null of emtpy!");
            
            var entity = await customerDbContext.Customers
                .FindAsync(new object[] { request.Id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            entity.FullName = request.Fullname;

            await customerDbContext.SaveChangesAsync(cancellation);
        }
    }
}
