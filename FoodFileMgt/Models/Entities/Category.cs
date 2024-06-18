namespace FoodFileMgt.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<Food> Foods { get; set; } = new HashSet<Food>();
    }
}
