namespace FoodFileMgt.Models.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string RoleId { get; set; } = default!;
        public Role Role { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
        public Address Address { get; set; } = default!;
        public Director Director { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public Manager Manager { get; set; } = default!;
    }
}
