namespace LenV.Demo.Application.Customers.Queries.GetCustomers
{
    public class CustomersQueryHandler : IQueryHandler<CustomersQuery, Customer[]>
    {
        private readonly ICustomerDbContext customerDbContext;

        public CustomersQueryHandler(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task<Customer[]> ExecuteQuery(CustomersQuery request, CancellationToken cancellationToken = default)
        {
            return await customerDbContext.Customers
                .AsNoTracking()
                .ToArrayAsync();
        }
    }
}
