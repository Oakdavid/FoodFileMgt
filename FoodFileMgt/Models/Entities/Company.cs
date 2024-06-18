namespace FoodFileMgt.Models.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string CACNumber { get; set; } = default!;
        public string LogoUrl { get; set; } = default!;
        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
        public Manager Manager { get; set; }

    }
}
