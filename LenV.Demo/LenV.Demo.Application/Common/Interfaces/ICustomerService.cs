namespace LenV.Demo.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<Domain.Entities.Customer[]> GetAllAsync();
    }
}
