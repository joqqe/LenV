namespace LenV.Demo.Application.Customers.Queries.GetCustomer
{
    public class CustomerQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
