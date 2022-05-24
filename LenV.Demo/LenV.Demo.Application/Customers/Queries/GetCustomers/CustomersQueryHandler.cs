namespace LenV.Demo.Application.Customers.Queries.GetCustomers
{
    public class CustomersQueryHandler : IRequestHandler<CustomersQuery, Customer[]>
    {
        private readonly ICustomerDbContext customerDbContext;

        public CustomersQueryHandler(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task<Customer[]> Handle(CustomersQuery request, CancellationToken cancellationToken)
        {
            return await customerDbContext.Customers
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}
