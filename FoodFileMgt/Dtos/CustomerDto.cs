using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.Dtos
{
    public class CustomerDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string TagNumber { get; set; } = default!;
        public ICollection<OrderDto> Orders { get; set; } = new HashSet<OrderDto>();
    }

    public class CreateCustomerRequestModel
    {
        public User User { get; set; } = default!;
    }
}
