using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Task<Branch> Get(string id);
        Task<Branch> Get(Expression<Func<Branch, bool>> predicate);
        Task<ICollection<Branch>> GetSelected(List<string> ids);
        Task<ICollection<Branch>> GetSelected(Expression<Func<Branch, bool>> predicate);
        Task<ICollection<Branch>> GetAll();
    }
}
