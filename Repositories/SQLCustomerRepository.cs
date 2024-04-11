using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NorthWind.Data;
using NorthWind.Models.Domain;
using System.Runtime.InteropServices.Marshalling;

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

        public async Task<Customer?> GetCustomerByIDAsync(string customer)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customer);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateAsync(string customerID, Customer customer)
        {
            var existingCustomer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerID);
            if (existingCustomer == null)
                return null;
            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.ContactTitle = customer.ContactTitle;
            existingCustomer.Address = customer.Address;
            existingCustomer.City = customer.City;
            existingCustomer.Region = customer.Region;
            existingCustomer.PostalCode = customer.PostalCode;
            existingCustomer.Country = customer.Country;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Fax = customer.Fax;
            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }

        public async Task<Customer?> DeleteAsync(string customerID)
        {
            var existingCustomer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerID);
            if (existingCustomer == null)
                return null;
            dbContext.Customers.Remove(existingCustomer);
            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }
    }
}
