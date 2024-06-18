namespace FoodFileMgt.Models.Entities
{
    public class FoodOrder : BaseEntity
    {
        public string FoodId { get; set; } = default!;
        public Food Food { get; set; } = default!;
        public string OrderId { get; set; } = default!;
        public Order Order { get; set; } = default!;
        public int Quantity { get; set; } = default!;
    }
}
