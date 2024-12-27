using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeriTabani2.Repositories;

namespace VeriTabani2.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync(); // Repository'den tüm ürünleri al
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id); // ID'ye göre ürün bul
        }

        public async Task AddProduct(Product product)
        {
            await _productRepository.AddAsync(product); // Yeni ürünü ekle
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateAsync(product); // Ürünü güncelle
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id); // Ürünü sil
        }
    }
}
