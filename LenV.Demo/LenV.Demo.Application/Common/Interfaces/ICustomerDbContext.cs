using Microsoft.EntityFrameworkCore;

namespace LenV.Demo.Application.Common.Interfaces
{
    public interface ICustomerDbContext
    {
        DbSet<Customer> Customers { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
