using Microsoft.EntityFrameworkCore;
using VeriTabani2.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeriTabani2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
