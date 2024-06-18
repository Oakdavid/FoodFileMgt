using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<Company> Get(string id);
        Task<Company> Get(Expression<Func<Company, bool>> predicate);
        Task<ICollection<Company>> GetSelected(Expression<Func<Company, bool>> predicate);
        Task<ICollection<Company>> GetSelected(List<string> ids);

        Task<ICollection<Company>> GetAll();
    }
}
