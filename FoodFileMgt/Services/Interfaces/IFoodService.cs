using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface IFoodService
    {
        Task<BaseResponse<FoodDto>> CreateFoodAsync(CreateFoodViewModel model);
    }
}
