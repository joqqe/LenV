using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Application.UnitTests
{
    public abstract class TestsBase : IDisposable
    {
        public ServiceProvider serviceProvider;

        // Called before every test method.
        protected TestsBase()
        {
            var services = new ServiceCollection();
            services.AddApplication();
            services.AddInfrastructure();

            serviceProvider = services.BuildServiceProvider();

            EnsureDatabase();
        }

        // Called after every test method.
        public void Dispose()
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

            context.Database.EnsureDeleted();
        }

        private void EnsureDatabase()
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

            context.Database.EnsureCreated();
        }
    }
}
