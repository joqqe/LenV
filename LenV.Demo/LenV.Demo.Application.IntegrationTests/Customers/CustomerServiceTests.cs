namespace LenV.Demo.Application.IntegrationTests.Customers
{
    public class CustomerServiceTests : TestsBase
    {
        [Fact]
        public async Task GetAll_Returns_2items()
        {
            var customerService = (ICustomerService)serviceProvider.GetService(typeof(ICustomerService));

            var customers = await customerService.GetAllAsync();

            Assert.Equal(2, customers.Length);
        }
    }
}