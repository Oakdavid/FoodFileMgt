using FoodFileMgt.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FoodFileMgt.Dtos
{
    public class UserDto
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string RoleId { get; set; } = default!;
        public string RoleName { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }

    public class CreateUserRequestModel
    {
        [Required (ErrorMessage = "it is required")]
        [EmailAddress (ErrorMessage = "invalid email address")]
        public string Email { get; set; } = default!;
        [Required]
        [StringLength(8, MinimumLength = 5)]
        public string Password { get; set; } = default!;
        [Compare("Password", ErrorMessage ="Password must be the same")]
        public string ConfirmPassword { get; set; } = default!;
        //public Profile Profile { get; set; } = default!;
        //public Address Address { get; set; } = default!;
        //public Director Director { get; set; } = default!;
        //public Customer Customer { get; set; } = default!;
        //public Manager Manager { get; set; } = default!;
    }

    public class LoginUserRequestModel
    {
        [Required(ErrorMessage = "it is required")]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Email { get; set; } = default!;
        [Required]
        [StringLength(8, MinimumLength = 5)]
        public string Password { get; set; } = default!;
    }
}
