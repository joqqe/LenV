
namespace LenV.Demo.Application.IntegrationTests
{
    public class CustomerService : TestsBase
    {
        [Fact]
        public async Task GetAll_Returns_2_items()
        {
            var customerService = (ICustomerService)serviceProvider.GetService(typeof(ICustomerService));

            var customers = await customerService.GetAllAsync();

            Assert.Equal(2, customers.Length);
        }
    }
}