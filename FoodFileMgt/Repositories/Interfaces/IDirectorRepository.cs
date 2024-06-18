using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        Task<Director> Get(string id);
        Task<Director> Get(Expression<Func<Director, bool>> predicate);
        Task<ICollection<Director>> GetSelected(Expression<Func<Director, bool>> predicate);
        Task<ICollection<Director>> GetAll();
        Task<ICollection<Director>> GetSelected(List<string> ids);
    }
}
