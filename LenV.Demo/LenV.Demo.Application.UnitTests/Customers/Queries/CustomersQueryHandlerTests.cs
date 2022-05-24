using LenV.Demo.Application.Customers.Queries.GetCustomers;

namespace LenV.Demo.Application.UnitTests.Customers.Queries
{
    public class CustomersQueryHandlerTests : TestsBase
    {
        [Fact]
        public async Task GetCustomers_returns_2items()
        {
            var handler = (IQueryHandler<CustomersQuery, Customer[]>)serviceProvider
                .GetService(typeof(IQueryHandler<CustomersQuery, Customer[]>));

            var entities = await handler.ExecuteQuery(new CustomersQuery { });

            Assert.Equal(2, entities.Length);
        }
    }
}
