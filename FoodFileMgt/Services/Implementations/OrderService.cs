using FoodFileMgt.Dtos;
using FoodFileMgt.Repositories.Implementations;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<BaseResponse<OrderDto>> CreateOrderAsync(CreateOrderViewModel model)
        {
            var exists = await _orderRepository.Get(a => a.Id == model.Order.CustomerId);
            if(exists != null)
            {
                return new BaseResponse<OrderDto>
                {
                    Data = null,
                    Message = "Order already exist",
                    Status = false,
                };
            }
            return new BaseResponse<OrderDto>
            {
                Data = null,
                Message = "Order already exist",
                Status = false,
            };
        }
    }
}
