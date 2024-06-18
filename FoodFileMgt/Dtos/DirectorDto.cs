using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class DirectorDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string BranchId { get; set; } = default!;
        public string BranchName { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
    }

    public class CreateDirectorRequestModel
    {
        public User User { get; set; } = default!;
        public Branch Branch { get; set; } = default!;
    }
}
