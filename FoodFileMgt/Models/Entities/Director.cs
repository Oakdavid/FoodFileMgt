namespace FoodFileMgt.Models.Entities
{
    public class Director : BaseEntity
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string BranchId { get; set; } = default!;
        public Branch Branch { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
    }
}
