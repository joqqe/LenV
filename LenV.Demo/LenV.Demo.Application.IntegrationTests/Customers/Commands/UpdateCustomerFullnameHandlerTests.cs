using LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname;
using LenV.Demo.Application.Customers.Queries.GetCustomer;

namespace LenV.Demo.Application.IntegrationTests.Customers.Commands
{
    public class UpdateCustomerFullnameHandlerTests : TestsBase
    {
        [Fact]
        public async Task Should_Update_Fullname_Customer()
        {
            var expect = "UpdatedCustomer";

            var updatHandler = (ICommandHandler<UpdateCustomerFullnameCommand>)serviceProvider
                .GetService(typeof(ICommandHandler<UpdateCustomerFullnameCommand>));

            await updatHandler.Execute(new UpdateCustomerFullnameCommand { Id = 1, Fullname = expect });

            var getHandler = (IQueryHandler<CustomerQuery, Customer>)serviceProvider
                .GetService(typeof(IQueryHandler<CustomerQuery, Customer>));

            var entity = await getHandler.ExecuteQuery(new CustomerQuery { Id = 1 });

            Assert.Equal(expect, entity.FullName);
        }
    }
}
