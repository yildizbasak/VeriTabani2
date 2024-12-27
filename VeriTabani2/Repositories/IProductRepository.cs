using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeriTabani2.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();         // Tüm ürünleri al
        Task<Product> GetByIdAsync(int id);        // ID'ye göre ürün al
        Task AddAsync(Product product);            // Yeni ürün ekle
        Task UpdateAsync(Product product);         // Ürün güncelle
        Task DeleteAsync(int id);                  // Ürün sil
    }
}
