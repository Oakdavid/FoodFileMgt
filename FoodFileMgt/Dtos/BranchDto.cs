using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class BranchDto
    {
        public string Id { get; set; } = default!;
        public string CompanyId { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string DirectorName { get; set; } = default!;
        public string BranchName { get; set; } = default!;
        public ICollection<FoodDto> Foods { get; set; } = new HashSet<FoodDto>();
    }

    public class CreateBranchRequestModel
    {
        public string CompanyId { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Director { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
