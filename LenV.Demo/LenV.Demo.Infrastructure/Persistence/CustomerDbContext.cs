using LenV.Demo.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LenV.Demo.Infrastructure.Persistence
{
    public class CustomerDbContext : DbContext, ICustomerDbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer { Id = 1, FullName = "Customer1", Type = CustomerTypes.Landbouw },
                    new Customer { Id = 2, FullName = "Customer2", Type = CustomerTypes.Visserij });

            base.OnModelCreating(modelBuilder);
        }
    }
}
