using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<ICollection<User>> GetSelected(Expression<Func<User, bool>> predicate);
        Task<User> Get(string id);
        Task<User> Get(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAll();
        Task<ICollection<User>> GetSelected(List<string> ids);
    }
}
