using Microsoft.EntityFrameworkCore;

namespace LenV.Demo.Application.Customers
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerDbContext customerDbContext;

        public CustomerService(ICustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task<Customer[]> GetAllAsync()
        {
            return await customerDbContext.Customers
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var entity = await customerDbContext.Customers
                .FindAsync(new object[] { id }, default);

            if(entity == null)
                throw new NotFoundException(nameof(Customer), id);

            return entity;
        }


    }
}
