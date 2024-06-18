using FoodFileMgt.Dtos;

namespace FoodFileMgt.ViewModels
{
    public class CreateOrderViewModel
    {
        public CreateOrderRequestModel Order { get; set; } = default!;
        public CreateFoodRequestModel Food { get; set; } = default!;
        public CreateBranchRequestModel Branch { get; set; } = default!;
    }
}
