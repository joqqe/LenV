using LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname;
using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Application
{
    public static class ConfigerServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Queries
            services.AddScoped<IQueryHandler<CustomersQuery, Customer[]>, CustomersQueryHandler>();
            services.AddScoped<IQueryHandler<CustomerQuery,Customer>, CustomerQueryHandler>();
            
            // Commands
            services.AddScoped<ICommandHandler<UpdateCustomerFullnameCommand>, UpdateCustomerFullnameCommandHandler> ();

            return services;
        }
    }
}
