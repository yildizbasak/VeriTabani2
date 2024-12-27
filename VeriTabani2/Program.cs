using Microsoft.EntityFrameworkCore;
using VeriTabani2.Data;
using VeriTabani2.Repositories;
using VeriTabani2.Services;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant�s�n� yap�land�r�yoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Repository ve Service s�n�flar�n� DI konteynerine ekliyoruz
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


// Controller hizmetini ekliyoruz
builder.Services.AddControllers();

// Swagger UI (Opsiyonel, API d�k�mantasyonu i�in)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Di�er servisleri ekleyin...

var app = builder.Build();

// API d�k�mantasyonunu kullanmak isterseniz, Swagger'� aktif edin
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// API Controllers'� ba�lay�yoruz
app.MapControllers();

app.Run();
