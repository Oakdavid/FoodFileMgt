using FoodFileMgt.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FoodFileMgt.Dtos
{
    public class AddressDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string BranchId { get; set; } = default!;
        public string BranchName { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
    }

    public class CreateAddressRequestModel
    {
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
    }
}
