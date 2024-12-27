using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeriTabani2.Data;

namespace VeriTabani2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor ile DbContext'i alıyoruz.
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // Tüm ürünleri listele
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id); // ID'ye göre ürün bul
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product); // Yeni ürün ekle
            await _context.SaveChangesAsync(); // Veritabanına kaydet
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product); // Ürünü güncelle
            await _context.SaveChangesAsync(); // Değişiklikleri kaydet
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id); // Ürünü ID ile bul
            if (product != null)
            {
                _context.Products.Remove(product); // Ürünü sil
                await _context.SaveChangesAsync(); // Veritabanına kaydet
            }
        }
    }
}
