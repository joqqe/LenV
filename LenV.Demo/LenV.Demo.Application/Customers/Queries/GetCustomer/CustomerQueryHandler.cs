namespace LenV.Demo.Application.Customers.Queries.GetCustomer
{
    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, Customer>
    {
        private readonly ICustomerDbContext customerDbContext;

        public CustomerQueryHandler(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }
        
        public async Task<Customer> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await customerDbContext.Customers
                .FindAsync(new object[] { request.Id }, default);

            return entity
                ?? throw new NotFoundException(nameof(Customer), request.Id);
        }
    }
}
