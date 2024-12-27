using Microsoft.EntityFrameworkCore;
using VeriTabani2.Repositories;

namespace VeriTabani2.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrders() => await _orderRepository.GetAllAsync();

        public async Task<Order> GetOrderById(int id) => await _orderRepository.GetByIdAsync(id);

        public async Task AddOrder(Order order) => await _orderRepository.AddAsync(order);

        public async Task UpdateOrder(Order order) => await _orderRepository.UpdateAsync(order);

        public async Task DeleteOrder(int id) => await _orderRepository.DeleteAsync(id);

        public async Task<int> GetTotalOrderAmount() => await _orderRepository.GetTotalOrderAmountAsync();

    }
}
