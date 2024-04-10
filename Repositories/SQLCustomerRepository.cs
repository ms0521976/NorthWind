using Microsoft.EntityFrameworkCore;
using NorthWind.Data;
using NorthWind.Models.Domain;

namespace NorthWind.Repositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly NorthWindContext dbContext;

        public SQLCustomerRepository(NorthWindContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }
    }
}
