using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<ICollection<Manager>> GetSelected(Expression<Func<Manager, bool>> predicate);
        Task<Manager> Get(string id);
        Task<Manager> Get(Expression<Func<Manager, bool>> predicate);
        Task<ICollection<Manager>> GetAll();
        Task<ICollection<Manager>> GetSelected(List<string> ids);
    }
}
