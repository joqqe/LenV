using LenV.Demo.Application.Customers.Queries.GetCustomer;

namespace LenV.Demo.Application.IntegrationTests.Customers.Queries
{
    public class CustomerQueryHandlerTests : TestsBase
    {
        [Fact]
        public async Task GetCustomer_Returns_1items() 
        {
            var handler = (IQueryHandler<CustomerQuery, Customer>)serviceProvider
                .GetService(typeof(IQueryHandler<CustomerQuery, Customer>));

            var entity = await handler.ExecuteQuery(new CustomerQuery { Id = 1 });

            Assert.Equal(1, entity.Id);
        }
    }
}
