namespace LenV.Demo.Application.UnitTests.Customers
{
    public class CustomerService : TestsBase
    {
        [Fact]
        public async Task GetAll_Returns_2items()
        {
            var customerService = (ICustomerService)serviceProvider.GetService(typeof(ICustomerService));

            var customers = await customerService.GetAllAsync();

            Assert.Equal(2, customers.Length);
        }

        [Fact]
        public async Task GetCustomer_Returns_1items()
        {
            var expected = "Customer1";

            var customerService = (ICustomerService)serviceProvider.GetService(typeof(ICustomerService));

            var customer = await customerService.GetByIdAsync(1);

            Assert.Equal(expected, customer.FullName);
        }
    }
}