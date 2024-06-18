using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class FoodDto
    {
        public string Id { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
        public string CategoryName { get; set; } = default!;
        public string FoodName { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double Price { get; set; } = default!;
        public ICollection<BranchDto> Branches { get; set; } = new HashSet<BranchDto>();
        public ICollection<OrderDto> Orders { get; set; } = new HashSet<OrderDto>();

    }

    public class CreateFoodRequestModel
    {
        public string Id { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
        public double Price { get; set; } = default!;

    }
}
