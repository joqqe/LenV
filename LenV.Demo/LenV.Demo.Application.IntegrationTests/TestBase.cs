﻿using Microsoft.Extensions.DependencyInjection;

namespace LenV.Demo.Application.IntegrationTests
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
        }

        // Called after every test method.
        public void Dispose()
        {
        }
    }
}
