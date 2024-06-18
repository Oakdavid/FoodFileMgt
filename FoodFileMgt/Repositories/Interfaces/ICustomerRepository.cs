using FoodFileMgt.Models.Entities;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> Get(string id);
        Task<Customer> Get(Expression<Func<Customer, bool>> predicate);
        Task<ICollection<Customer>> GetSelected(Expression<Func<Customer, bool>> predicate);
        Task<ICollection<Customer>> GetAll();
        Task<ICollection<Customer>> GetSelected(List<string> ids);
    }
}
