using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeriTabani2.Services;

namespace VeriTabani2.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet("top-ordered-product")]
        public async Task<ActionResult<Product>> GetTopOrderedProduct()
        {
            var orders = await _orderService.GetAllOrders();
            var topProduct = orders.GroupBy(o => o.ProductId).OrderByDescending(g => g.Sum(o => o.Quantity))
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalQuantity = g.Sum(o => o.Quantity)
                })
            .FirstOrDefault();

            return Ok(topProduct);
        }

        [HttpGet("after-date")]
        public async Task<ActionResult<List<Order>>> GetOrdersAfterDate([FromQuery] DateTime date)
        {
            var orders = await _orderService.GetAllOrders();
            var ordersAfterDate = orders
                .Where(o => o.OrderDate > date).ToList();
            return Ok(ordersAfterDate);
        }



        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest("Order details are not valid.");

            await _orderService.AddOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] Order order)
        {
            if (id != order.Id)
                return BadRequest();

            await _orderService.UpdateOrder(order);
            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
                return NotFound();

            await _orderService.DeleteOrder(id);
            return NoContent();
        }

        // GET: api/orders/total
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalOrderAmount()
        {
            var total = await _orderService.GetTotalOrderAmount();
            return Ok(total);
        }
    }
}
