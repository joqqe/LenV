namespace LenV.Demo.Application.Email.Send
{
    public class SendEmailNotification : INotification
    {
        public string? To { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
