using NorthWind.Models.Domain;

namespace NorthWind.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetCustomerByIDAsync(string customer);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(string customerID, Customer customer);
        Task<Customer?> DeleteAsync(string customerID);
    }
}
