using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> Get(string id);
        Task<Category> Get(Expression<Func<Category, bool>> predicate);
        Task<ICollection<Category>> GetSelected(List<string> ids);
        Task<ICollection<Category>> GetSelected(Expression<Func<Category, bool>> predicate);
        Task<ICollection<Category>>GetAll();
    }
}
