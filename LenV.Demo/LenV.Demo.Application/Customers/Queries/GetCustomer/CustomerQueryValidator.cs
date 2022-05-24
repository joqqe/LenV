namespace LenV.Demo.Application.Customers.Queries.GetCustomer
{
    public class CustomerQueryValidator : AbstractValidator<CustomerQuery>
    {
        public CustomerQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id at least greater than or equal to 1.");
        }
    }
}
