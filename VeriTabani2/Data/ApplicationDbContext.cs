using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace VeriTabani2.Data  // Bu isim proje adına göre değişebilir.
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
