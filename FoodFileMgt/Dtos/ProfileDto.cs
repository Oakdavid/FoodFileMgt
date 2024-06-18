using FoodFileMgt.Models.Entities;
using FoodFileMgt.Models.Enums;

namespace FoodFileMgt.Dtos
{
    public class ProfileDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public DateTime Dob { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
    }

    public class CreateProfileRequestModel
    {
        public User User { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
        public DateTime Dob { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
    }
}
