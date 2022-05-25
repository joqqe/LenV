using LenV.Demo.Application.Customers.Queries.GetCustomer;

namespace LenV.Demo.Application.UnitTests.Customers.Queries
{
    public class CustomerQueryHandlerTests : TestsBase
    {
        [Fact]
        public async Task GetCustomer_Returns_1items() 
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var entity = await mediator.Send(new CustomerQuery { Id = 1 });

            Assert.Equal(1, entity.Id);
        }

        [Fact]
        public async Task GetCustomer_WithIdOf0_ThrowsArgumentOutOfRangeException()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));
            try
            {
                await mediator.Send(new CustomerQuery { Id = 0 });
                Assert.True(false);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.True(ex.ParamName == "Id should be greater than 0.");
            }
        }
    }
}
