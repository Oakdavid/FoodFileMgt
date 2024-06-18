using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetSelected(Expression<Func<Role, bool>> predicate);
        Task<Role> Get(string id);
        Task<Role> Get(Expression<Func<Role, bool>> predicate);
        Task<ICollection<Role>> GetAll();
        Task<ICollection<Role>> GetSelected(List<string> ids);
    }
}
