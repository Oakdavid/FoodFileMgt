using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseResponse<CustomerDto>> CreateCustomerAsync(CreateCustomerViewModel model);
    }
}
