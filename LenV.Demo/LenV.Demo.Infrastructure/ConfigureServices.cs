using LenV.Demo.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, Action<InfraOptions> options)
        {
            var infraOptions = new InfraOptions();
            options(infraOptions);

            switch (infraOptions.DbType)
            {
                case DbTypes.SqLite:
                default:
                    services.UseSqLite(infraOptions);
                    break;
            }

            services.AddScoped<ICustomerDbContext>(provider => provider.GetRequiredService<CustomerDbContext>());

            return services;
        }

        private static IServiceCollection UseSqLite(this IServiceCollection services, InfraOptions infraOptions)
        {
            var connection = new SqliteConnection(infraOptions.ConnectionString ?? "DataSource=:memory:");
            connection.Open();

            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            return services;
        }
    }

    public class InfraOptions
    {
        public DbTypes DbType { get; set; } = DbTypes.SqLite;
        public string? ConnectionString { get; set; }
    }

    public enum DbTypes
    {
        /// <summary>
        /// Default ConnectionString: "DataSource=:memory:"
        /// </summary>
        SqLite
    }
}