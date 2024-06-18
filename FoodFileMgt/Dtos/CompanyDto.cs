using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class CompanyDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CACNumber { get; set; } = default!;
        public string LogoUrl { get; set; } = default!;
        public ICollection<BranchDto> Branches { get; set; } = new HashSet<BranchDto>();
        public string ManagerName { get; set; } = default!;
    }

    public class CreateCompanyRequestModel
    {
        public string Name { get; set; } = default!;
        public string CACNumber { get; set; } = default!;
        public IFormFile LogoUrl { get; set; } = default!;
        //public Manager Manager { get; set; } = default!;
    }
}
