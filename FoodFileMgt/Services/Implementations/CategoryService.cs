using FoodFileMgt.Dtos;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Implementations;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;


namespace FoodFileMgt.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryRequestModel model)
        {
            var exists = await _categoryRepository.Get(a => a.Name == model.Name);
            if (exists != null)
            {
                return new BaseResponse<CategoryDto>
                {
                    Status = false,
                    Message = "already exist",
                    Data = null,
                };
            }

            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,
            };
            await _categoryRepository.Create(category);
            await _categoryRepository.Save();

            return new BaseResponse<CategoryDto>
            {
                Message = "success",
                Status = true,
                Data = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Foods = (ICollection<FoodDto>)category.Foods

                }
            };
        }
            
    }
}
