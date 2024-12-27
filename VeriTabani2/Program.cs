using Microsoft.EntityFrameworkCore;
using VeriTabani2.Data;
using VeriTabani2.Repositories;
using VeriTabani2.Services;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsýný yapýlandýrýyoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Repository ve Service sýnýflarýný DI konteynerine ekliyoruz
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


// Controller hizmetini ekliyoruz
builder.Services.AddControllers();

// Swagger UI (Opsiyonel, API dökümantasyonu için)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Diðer servisleri ekleyin...

var app = builder.Build();

// API dökümantasyonunu kullanmak isterseniz, Swagger'ý aktif edin
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// API Controllers'ý baðlayýyoruz
app.MapControllers();

app.Run();
