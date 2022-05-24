namespace LenV.Demo.Application.Common.Interfaces
{
    public interface ICommandHandler<TIn>
    {
        Task Execute(TIn request, CancellationToken cancellation = default);
    }
}
