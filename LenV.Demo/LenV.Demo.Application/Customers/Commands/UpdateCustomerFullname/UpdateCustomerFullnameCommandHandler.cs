using LenV.Demo.Application.Email.Send;

namespace LenV.Demo.Application.Customers.Commands.UpdateCustomerFullname
{
    public class UpdateCustomerFullnameCommandHandler : IRequestHandler<UpdateCustomerFullnameCommand>
    {
        private readonly ICustomerDbContext customerDbContext;
        private readonly IMediator mediator;

        public UpdateCustomerFullnameCommandHandler(ICustomerDbContext customerDbContext, IMediator mediator)
        {
            this.customerDbContext = customerDbContext;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateCustomerFullnameCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Fullname))
                throw new ArgumentException("Argument Fullname should not be null of emtpy!");

            var entity = await customerDbContext.Customers
                .FindAsync(new object[] { request.Id }, default);

            if (entity == null)
                throw new NotFoundException(nameof(Customer), request.Id);

            entity.FullName = request.Fullname;

            await customerDbContext.SaveChangesAsync(cancellationToken);

            await mediator.Publish(new SendEmailNotification
            {
                To = "", // jochen.schoonjans@rrealdolmen.com
                Title = "Updated Customer",
                Body = $"New fullname is {entity.FullName}"
            });

            return Unit.Value;
        }
    }
}
