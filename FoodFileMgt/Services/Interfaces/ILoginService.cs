using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface ILoginService
    {
        Task<BaseResponse<UserDto>> Login(LoginUserRequestModel model);
    }
}
