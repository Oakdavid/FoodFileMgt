using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class RoleDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<UserDto> Users { get; set; } = new HashSet<UserDto>();
    }

    public class CreateRoleRequestModel
    {
        public string Name { get; set; } = default!;
    }
}
