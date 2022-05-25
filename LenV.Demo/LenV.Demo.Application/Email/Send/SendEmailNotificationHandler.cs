namespace LenV.Demo.Application.Email.Send
{
    public class SendEmailNotificationHandler : INotificationHandler<SendEmailNotification>
    {
        public Task Handle(SendEmailNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email send to: {notification.To} " +
                $"with title: {notification.Title} " +
                $"and body: {notification.Body}");

            return Task.CompletedTask;
        }
    }
}
