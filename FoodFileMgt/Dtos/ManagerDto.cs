using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class ManagerDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string ComapanyId { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
    }

    public class CreateManagerRequestModel
    {
        //public User User { get; set; } = default!;
        //public Company Company { get; set; } = default!;
    }
}
