using FoodFileMgt.Dtos;

namespace FoodFileMgt.ViewModels
{
    public class CreateFoodViewModel
    {
        public CreateFoodRequestModel Food { get; set; } = default!;
        public CreateBranchRequestModel Branch { get; set; } = default!;
    }
}
