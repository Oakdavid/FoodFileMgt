using FoodFileMgt.Models.Enums;

namespace FoodFileMgt.Models.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
        public string RefNumber { get; set; } = default!;
        public OrderStatus Status { get; set; } = default!;
        public ICollection<FoodOrder> FoodOrders { get; set; } = new HashSet<FoodOrder>();
        public double TotalPrice { get; set; }
    }
}
