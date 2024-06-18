namespace FoodFileMgt.Models.Entities
{
    public class Customer : BaseEntity
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string TagNumber { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
