using FluentValidation;
using LenV.Demo.Application.Email.Send;

namespace LenV.Demo.Application.UnitTests.Customers.Notifications
{
    public class SendEmailNotificationHandlerTests : TestsBase
    {
        [Fact]
        public async Task Send_Empty_email_Should_Throw_exception()
        {
            var mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));

            try
            {
                await mediator.Publish(new SendEmailNotification());

                Assert.True(false);
            }
            catch (ValidationException)
            {
                Assert.True(true);
            }
        }
    }
}
