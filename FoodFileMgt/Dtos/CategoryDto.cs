using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class CategoryDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<FoodDto> Foods { get; set; } = new HashSet<FoodDto>();
    }

    public class CreateCategoryRequestModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
