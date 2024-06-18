namespace FoodFileMgt.Models.Entities
{
    public class FoodBranch : BaseEntity
    {
        public string FoodId { get; set; } = default!;
        public Food Food { get; set; } = default!;
        public string BranchId { get; set; } = default!;
        public Branch Branch { get; set; } = default!;
        public int QuantityAvailable { get; set; } = default!;
    }
}
