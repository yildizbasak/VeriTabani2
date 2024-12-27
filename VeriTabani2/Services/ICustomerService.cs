using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeriTabani2.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}
