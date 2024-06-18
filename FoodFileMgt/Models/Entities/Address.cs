namespace FoodFileMgt.Models.Entities
{
    public class Address : BaseEntity
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string BranchId { get; set; } = default!;
        public Branch Branch { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}
