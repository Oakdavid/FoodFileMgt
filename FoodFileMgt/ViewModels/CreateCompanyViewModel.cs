using FoodFileMgt.Dtos;

namespace FoodFileMgt.ViewModels
{
    public class CreateCompanyViewModel
    {
        public CreateCompanyRequestModel Company { get; set; }
        public CreateUserRequestModel User { get; set; }
        public CreateAddressRequestModel Address { get; set; }
        public CreateProfileRequestModel Profile { get; set; }
    }
}
