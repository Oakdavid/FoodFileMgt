using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        Task<ICollection<Food>> GetSelected(Expression<Func<Food, bool>> predicate);
        Task<Food> Get(string id);
        Task<Food> Get(Expression<Func<Food, bool>> predicate);
        Task<ICollection<Food>> GetAll();
        Task<ICollection<Food>> GetSelected(List<string> ids);
    }
}
