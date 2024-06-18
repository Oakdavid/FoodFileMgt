namespace FoodFileMgt.Models.Entities
{
    public class Food : BaseEntity
    {
        public string CategoryId { get; set; } = default!;
        public Category Category { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double Price { get; set; } = default!;
        public ICollection<FoodBranch> FoodBranches { get; set; } = new HashSet<FoodBranch>();
        public ICollection<FoodOrder> FoodOrders { get; set; } = new HashSet<FoodOrder>();
        
    }
}
