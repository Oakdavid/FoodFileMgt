using FoodFileMgt.Dtos;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IManagerRepository _managerRepository;

        public CompanyService(ICompanyRepository companyRepository, IRoleRepository roleRepository, IUserRepository userRepository,IAddressRepository addressRepository, IFileRepository fileRepository, IProfileRepository profileRepository, IManagerRepository managerRepository)
        {
            _companyRepository = companyRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _fileRepository = fileRepository;
            _profileRepository = profileRepository;
            _managerRepository = managerRepository;

        }
        public async Task<BaseResponse<CompanyDto>> CreateCompanyAsync(CreateCompanyViewModel model)
        {
            var exists = await _companyRepository.Get(a => a.CACNumber == model.Company.CACNumber);

            if(exists != null)
            {
                return new BaseResponse<CompanyDto>
                {
                    Status = false,
                    Message = "already exist",
                    Data = null,
                };
            }

            var role = await _roleRepository.Get(a => a.Name == "Manager");

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

            var company = new Company
            {
                LogoUrl = _fileRepository.Upload(model.Company.LogoUrl),
                CACNumber = model.Company.CACNumber,
                Name = model.Company.Name,

            };
            await _companyRepository.Create(company);

            var manager = new Manager
            {
                ComapanyId = company.Id,
                StaffNumber = $"CLH/MNG/{new Random().Next(1000, 9999)}",
                User = user,
                UserId = user.Id,
            };

            await _managerRepository.Create(manager);

            await _managerRepository.Save();

            return new BaseResponse<CompanyDto>
            {
                Message = "success",
                Status = true,
                Data = new CompanyDto
                {
                    Id = company.Id,
                    CACNumber = company.CACNumber,
                    ManagerName = $"{manager.User.Profile.FirstName} {manager.User.Profile.LastName}",
                    Name = company.Name,
                    LogoUrl = company.LogoUrl,

                }
            };
        }
    }
}
