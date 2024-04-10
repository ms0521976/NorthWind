using NorthWind.Models.Domain;

namespace NorthWind.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
    }
}
