using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> Get(string id);
        Task<Order> Get(Expression<Func<Order, bool>> predicate);
        Task<ICollection<Order>> GetAll();
        Task<ICollection<Order>> GetSelected(List<string> ids);
        Task<ICollection<Order>> GetSelected(Expression<Func<Order, bool>> predicate);
    }
}
