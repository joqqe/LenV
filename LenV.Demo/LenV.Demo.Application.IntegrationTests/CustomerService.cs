
namespace LenV.Demo.Application.IntegrationTests
{
    public class CustomerService : TestsBase
    {
        [Fact]
        public async Task Test1()
        {
            var customerService = (ICustomerService)serviceProvider.GetService(typeof(ICustomerService));

            var customers = await customerService.GetAllAsync();

            Assert.Equal(2, customers.Length);
        }
    }
}