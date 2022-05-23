using LenV.Demo.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connectionString = "DataSource=:memory:;mode=memory;cache=shared";
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddScoped<ICustomerDbContext>(provider => provider.GetRequiredService<CustomerDbContext>());

            return services;
        }
    }
}