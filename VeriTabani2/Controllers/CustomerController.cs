using Microsoft.AspNetCore.Mvc;
using VeriTabani2.Services;


namespace VeriTabani2.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService; // CustomerService eklenmeli

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync(); // CustomerService kullanarak müşteri listesi alınır
            return Ok(customers);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Customer details are not valid.");

            await _customerService.AddAsync(customer); // Customer servisine eklenir
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }
    }
}
