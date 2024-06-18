using FoodFileMgt.Dtos;
using FoodFileMgt.Repositories.Interfaces;
using FoodFileMgt.Services.Interfaces;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<UserDto>> Login(LoginUserRequestModel model)
        {
            var user = await _userRepository.Get(a => a.Email == model.Email);
            if (user == null)
            {
                return new BaseResponse<UserDto>()
                {
                    Status = false,
                    Message = "invalid cridentials",
                    Data = null
                };
            }
            if(BCrypt.Net.BCrypt.Verify(model.Password,user.Password))
            {
                return new BaseResponse<UserDto>()
                {
                    Message = "login successful",
                    Status = true,
                    Data = new UserDto()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Address = $"No {user.Address.Number}, {user.Address.Street} str, {user.Address.City} {user.Address.State} state",
                        FullName = $"{user.Profile.FirstName} {user.Profile.LastName}",
                        ImageUrl = user.Profile.ImageUrl,
                        Phone = user.Profile.PhoneNumber,
                        RoleId = user.RoleId,
                        RoleName = user.Role.Name,

                    }

                };
            }
            return new BaseResponse<UserDto>()
            {
                Status = false,
                Message = "invalid cridentials",
                Data = null
            };
        }
    }
}
