using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Application
{
    public static class ConfigerServices
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
