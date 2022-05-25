using LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname;
using LenV.Demo.Application.Customers.Queries.GetCustomer;
using LenV.Demo.Application.Customers.Queries.GetCustomers;

namespace LenV.Demo.MinApi.Endpoints
{
    public static class CustomerEndpoints
    {
        public static WebApplication UseCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customers", async (IMediator mediatr) =>
            {
                return await mediatr.Send(new CustomersQuery { });
            })
            .WithName("GetCustomers");

            app.MapGet("/customer/{id}", async (IMediator mediatr, int id) =>
            {
                return await mediatr.Send(new CustomerQuery { Id = id });
            })
            .WithName("GetCustomer");

            app.MapPut("/customer", async (IMediator mediatr, UpdateCustomerFullnameCommand updateCustomerFullnameCommand) =>
            {
                await mediatr.Send(updateCustomerFullnameCommand);

                return Results.Ok();
            })
            .WithName("UpdateCustomerFullname");

            return app;
        }
    }
}
