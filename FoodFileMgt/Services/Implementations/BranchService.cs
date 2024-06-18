using BCrypt.Net;
using FoodFileMgt.Dtos;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Implementations;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IDirectorRepository _directorRepository;

        public BranchService(IBranchRepository branchRepository, IRoleRepository roleRepository, IUserRepository userRepository, IProfileRepository profileRepository, IAddressRepository addressRepository, IFileRepository fileRepository, IDirectorRepository directorRepository)
        {
            _branchRepository = branchRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _addressRepository = addressRepository;
            _fileRepository = fileRepository;
            _directorRepository = directorRepository;
        }

        public async Task<BaseResponse<BranchDto>> CreateCompanyAsync(CreateBranchViewModel model)
        {
            var exists = await _branchRepository.Get(a => a.Name == model.Branch.Name);
            if (exists != null)
            {
                return new BaseResponse<BranchDto>
                {
                    Status = false,
                    Message = "already exist",
                    Data = null,
                };
            }

            var role = await _roleRepository.Get(a => a.Name == "Director");

            if(model.User.Password != model.User.ConfirmPassword)
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

            var branch = new Branch
            {
                 Address = address,
                 Name = model.Branch.Name,
                  
            };
            await _branchRepository.Create(branch);

            var director = new Director
            {
                UserId = user.Id,
                User = user,
                BranchId = branch.Id,
                Branch = branch,
                StaffNumber = $"CLH/DIR/{new Random().Next(1000, 9999)}",

            };
            await _directorRepository.Create(director);

            await _directorRepository.Save();

            return new BaseResponse<BranchDto>
            {
                Message = "success",
                Status = true,
                Data = new BranchDto
                {
                    Id = branch.Id,
                    DirectorName = $"{branch.Director.User.Profile.FirstName} {branch.Director.User.Profile.LastName}",
                    BranchName = branch.Name,
                    Address = $"{ branch.Address.Number } {branch.Address.Street} {branch.Address.State}"
                }
            };


        }
    }
}
