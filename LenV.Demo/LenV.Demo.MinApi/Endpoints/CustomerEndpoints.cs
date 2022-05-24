using LenV.Demo.Application.Common.Interfaces;
using LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname;
using LenV.Demo.Application.Customers.Queries.GetCustomer;
using LenV.Demo.Application.Customers.Queries.GetCustomers;
using LenV.Demo.Domain.Entities;

namespace LenV.Demo.MinApi.Endpoints
{
    public static class CustomerEndpoints
    {
        public static WebApplication UseCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customers", async (IQueryHandler<CustomersQuery, Customer[]> customerQueryHandler) =>
            {
                return await customerQueryHandler.ExecuteQuery(new CustomersQuery { });
            })
            .WithName("GetCustomers");

            app.MapGet("/customer/{id}", async (IQueryHandler<CustomerQuery, Customer> customerQueryHandler, int id) =>
            {
                return await customerQueryHandler.ExecuteQuery(new CustomerQuery { Id = id });
            })
            .WithName("GetCustomer");

            app.MapPut("/customer", async (ICommandHandler<UpdateCustomerFullnameCommand> updateCustomerFullnameHandler, UpdateCustomerFullnameCommand updateCustomerFullnameCommand) =>
            {
                await updateCustomerFullnameHandler.Execute(updateCustomerFullnameCommand);

                return Results.Ok();
            })
            .WithName("UpdateCustomerFullname");

            return app;
        }
    }
}
