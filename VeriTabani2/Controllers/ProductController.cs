using Microsoft.AspNetCore.Mvc;
using VeriTabani2.Services;

namespace VeriTabani2.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("expensive-products")]
        public async Task<IActionResult> GetExpensiveProducts()
        {
            var products = await _productService.GetAllProducts();
            var expensiveProducts = products.Where(p => p.Price > 500).ToList();
            return Ok(expensiveProducts);
        }

        [HttpGet("total-stock")]
        public async Task<ActionResult<int>> GetTotalStock()
        {
            var products = await _productService.GetAllProducts();
            var totalStock = products.Sum(p => p.Stock);
            return Ok(totalStock);
        }


        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Product details are not valid.");

            await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _productService.UpdateProduct(product);
            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
