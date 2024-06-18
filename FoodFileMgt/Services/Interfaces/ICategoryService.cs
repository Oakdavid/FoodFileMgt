using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryRequestModel model);
    }
}
