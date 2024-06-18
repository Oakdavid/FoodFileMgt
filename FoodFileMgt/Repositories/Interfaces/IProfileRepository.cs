using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<ICollection<Profile>> GetSelected(Expression<Func<Profile, bool>> predicate);
        Task<Profile> Get(string id);
        Task<Profile> Get(Expression<Func<Profile, bool>> predicate);
        Task<ICollection<Profile>> GetAll();
        Task<ICollection<Profile>> GetSelected(List<string> ids);
    }
}
