using FoodFileMgt.Models.Enums;

namespace FoodFileMgt.Models.Entities
{
    public class Profile : BaseEntity
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public DateTime Dob { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
    }
}
