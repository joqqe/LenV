namespace LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname
{
    public class UpdateCustomerFullnameCommand : IRequest
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = default!;
    }
}
