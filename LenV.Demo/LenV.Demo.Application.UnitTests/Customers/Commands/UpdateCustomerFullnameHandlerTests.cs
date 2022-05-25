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

        [Fact]
        public async Task UpdateFullname_WithIdOf0_ThrowsArgumentOutOfRangeException()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            try
            {
                await mediator.Send(new UpdateCustomerFullnameCommand { Id = 0, Fullname = "UpdatedCustomer" });

                Assert.True(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task UpdateFullname_WithNullFullname_ThrowsArgumentNullException()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            try
            {
                await mediator.Send(new UpdateCustomerFullnameCommand { Id = 1, Fullname = null });

                Assert.True(false);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task UpdateFullname_WithEmptyFullname_ThrowsArgumentException()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            try
            {
                await mediator.Send(new UpdateCustomerFullnameCommand { Id = 1, Fullname = String.Empty });

                Assert.True(false);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }
        }
    }
}
