using FoodFileMgt.Dtos;

namespace FoodFileMgt.ViewModels
{
    public class CreateCustomerViewModel
    {
        public CreateUserRequestModel User { get; set; }
        public CreateProfileRequestModel Profile { get; set; }
        public CreateAddressRequestModel Address { get; set; }
    }
}
