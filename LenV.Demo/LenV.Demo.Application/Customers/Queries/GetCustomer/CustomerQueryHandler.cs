namespace LenV.Demo.Application.Customers.Queries.GetCustomer
{
    public class CustomerQueryHandler : IQueryHandler<CustomerQuery, Customer>
    {
        private readonly ICustomerDbContext customerDbContext;

        public CustomerQueryHandler(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }
        public async Task<Customer> ExecuteQuery(CustomerQuery request, CancellationToken cancellationToken = default)
        {
            var entity = await customerDbContext.Customers
                .FindAsync(new object[] { request.Id }, default);
            
            return entity 
                ?? throw new NotFoundException(nameof(Customer), request.Id);
        }
    }
}
