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

            return app;
        }
    }
}
