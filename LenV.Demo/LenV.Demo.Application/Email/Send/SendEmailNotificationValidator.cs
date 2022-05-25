namespace LenV.Demo.Application.Email.Send
{
    public class SendEmailNotificationValidator : AbstractValidator<SendEmailNotification>
    {
        public SendEmailNotificationValidator()
        {
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("To should not be null or empty.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("To should not be null or empty.");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("To should not be null or empty.");
        }
    }
}
