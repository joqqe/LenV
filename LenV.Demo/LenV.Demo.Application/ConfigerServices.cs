using LenV.Demo.Application.Common.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Application
{
    public static class ConfigerServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }
    }
}
