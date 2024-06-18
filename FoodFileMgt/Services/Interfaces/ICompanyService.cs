using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<BaseResponse<CompanyDto>> CreateCompanyAsync(CreateCompanyViewModel model);
    }
}
