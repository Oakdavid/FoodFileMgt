namespace FoodFileMgt.Models.Entities
{
    public class Manager : BaseEntity
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
        //public Company Company { get; set; }
        public string ComapanyId { get; set; } = default!;
    }
}
