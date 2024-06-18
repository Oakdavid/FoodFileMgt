namespace FoodFileMgt.Models.Entities
{
    public class Branch : BaseEntity
    {
        public string CompanyId { get; set; } = default!;
        public Company Company { get; set; } = default!;
        public Address Address { get; set; } = default!;
        public Director Director { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<FoodBranch> FoodBranches { get; set; } = new HashSet<FoodBranch>();
    }
}
