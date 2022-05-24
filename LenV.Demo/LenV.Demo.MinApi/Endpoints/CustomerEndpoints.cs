namespace LenV.Demo.MinApi.Endpoints
{
    public static class CustomerEndpoints
    {
        public static WebApplication UseCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customers", async (ICustomerService customerService) =>
            {
                return await customerService.GetAllAsync();
            })
            .WithName("GetCustomers");

            app.MapGet("/customer/{id}", async (ICustomerService customerService, int id) =>
            {
                return await customerService.GetByIdAsync(id);
            })
            .WithName("GetCustomer");

            return app;
        }
    }
}
