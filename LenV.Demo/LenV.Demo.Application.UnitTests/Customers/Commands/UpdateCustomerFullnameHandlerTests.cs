using LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname;
using LenV.Demo.Application.Customers.Queries.GetCustomer;

namespace LenV.Demo.Application.UnitTests.Customers.Commands
{
    public class UpdateCustomerFullnameHandlerTests : TestsBase
    {
        [Fact]
        public async Task Should_Update_Fullname_Customer()
        {
            var expect = "UpdatedCustomer";

            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            await mediator.Send(new UpdateCustomerFullnameCommand { Id = 1, Fullname = expect });

            var entity = await mediator.Send(new CustomerQuery { Id = 1 });

            Assert.Equal(expect, entity.FullName);
        }
    }
}
