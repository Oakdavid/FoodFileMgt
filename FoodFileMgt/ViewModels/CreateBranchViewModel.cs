using FoodFileMgt.Dtos;
using FoodFileMgt.Models.Entities;

namespace FoodFileMgt.ViewModels
{
    public class CreateBranchViewModel
    {

        public CreateBranchRequestModel Branch { get; set; } = default!;
        public CreateAddressRequestModel Address { get; set; } = default!;
        public CreateUserRequestModel User { get; set; } = default!;
        public CreateProfileRequestModel Profile { get; set; } = default!;

    }
}
