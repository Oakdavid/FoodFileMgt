using FoodFileMgt.Models.Entities;
using FoodFileMgt.Models.Enums;

namespace FoodFileMgt.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; } = default!;
        public string CustomerId { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public string RefNumber { get; set; } = default!;
        public OrderStatus Status { get; set; } = default!;
        public ICollection<FoodDto> Foods { get; set; } = new HashSet<FoodDto>();
        public double TotalPrice { get; set; }
    }

    public class CreateOrderRequestModel
    {
        public string CustomerId { get; set; } = default!;
        public ICollection<FoodDto> Foods { get; set; } = new HashSet<FoodDto>();
    }
}
