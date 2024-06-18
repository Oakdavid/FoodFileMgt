using FoodFileMgt.Dtos;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Implementations;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {

            _foodRepository = foodRepository;

        }
        public async Task<BaseResponse<FoodDto>> CreateFoodAsync(CreateFoodViewModel model)
        {
            var exists = await _foodRepository.Get(a => a.Name == model.Food.Name);
            if (exists != null)
            {
                return new BaseResponse<FoodDto>
                {
                    Status = false,
                    Message = "already exist",
                    Data = null,
                };
            }
            return new BaseResponse<FoodDto>
            {
                Status = false,
                Message = "already exist",
                Data = null,
            };
        }
    }
}
