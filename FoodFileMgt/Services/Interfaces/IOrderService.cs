using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResponse<OrderDto>> CreateOrderAsync(CreateOrderViewModel model);
    }
}
