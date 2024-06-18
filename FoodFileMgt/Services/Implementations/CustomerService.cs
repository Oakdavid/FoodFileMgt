using FoodFileMgt.Dtos;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IProfileRepository _profileRepository;

        public CustomerService(ICustomerRepository companyRepository, IRoleRepository roleRepository, IUserRepository userRepository, IAddressRepository addressRepository, IFileRepository fileRepository, IProfileRepository profileRepository)
        {
            _customerRepository = companyRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _fileRepository = fileRepository;
            _profileRepository = profileRepository;
        }
        public async Task<BaseResponse<CustomerDto>> CreateCustomerAsync(CreateCustomerViewModel model)
        {
                
           var exists = await _customerRepository.Get(a => a.User.Email == model.User.Email);

            if (exists != null)
            {
                return new BaseResponse<CustomerDto>
                {
                    Status = false,
                    Message = "already exist",
                    Data = null,
                };
            }

            var role = await _roleRepository.Get(a => a.Name == "Customer");
            if (model.User.Password != model.User.ConfirmPassword)
            {
                return null;
            }

            var user = new User
            {
                Email = model.User.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.User.Password),
                RoleId = role.Id,
                Role = role,

            };
            await _userRepository.Create(user);

            var address = new Address
            {
                Number = model.Address.Number,
                Street = model.Address.Street,
                City = model.Address.City,
                State = model.Address.State,
                UserId = user.Id,
                User = user,
            };

            await _addressRepository.Create(address);

            var profile = new Profile
            {
                FirstName = model.Profile.FirstName,
                LastName = model.Profile.LastName,
                Dob = model.Profile.Dob,
                Gender = model.Profile.Gender,
                ImageUrl = _fileRepository.Upload(model.Profile.ImageUrl),
                PhoneNumber = model.Profile.PhoneNumber,
                User = user,
                UserId = user.Id,
            };
            await _profileRepository.Create(profile);

            var customer = new Customer
            {
                    User = user,
                    UserId = user.Id,
                    TagNumber = $"CLH/CUS/{new Random().Next(1000, 9999)}",
                     
            };
            await _customerRepository.Create(customer);
            await _customerRepository.Save();

            await _customerRepository.Save();

            return new BaseResponse<CustomerDto>
            {
                Message = "success",
                Status = true,
                Data = new CustomerDto
                {
                        Id = customer.Id,
                        FullName = $"{customer.User.Profile.FirstName} {customer.User.Profile.LastName}",
                        TagNumber = customer.TagNumber,
                        UserId= user.Id,

                }
            };
        }
    }
}
