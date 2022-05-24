using LenV.Demo.Application.Customers.Queries.GetCustomers;

namespace LenV.Demo.Application.UnitTests.Customers.Queries
{
    public class CustomersQueryHandlerTests : TestsBase
    {
        [Fact]
        public async Task GetCustomers_returns_2items()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            var entities = await mediator.Send(new CustomersQuery { });

            Assert.Equal(2, entities.Length);
        }
    }
}
