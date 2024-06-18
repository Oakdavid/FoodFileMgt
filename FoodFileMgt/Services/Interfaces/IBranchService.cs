using FoodFileMgt.Dtos;
using FoodFileMgt.ViewModels;

namespace FoodFileMgt.Services.Interfaces
{
    public interface IBranchService
    {
        Task<BaseResponse<BranchDto>> CreateCompanyAsync(CreateBranchViewModel model);
    }
}
