using FoodFileMgt.Models.Entities;
using System;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> Get(string id);
        Task<Address> Get(Expression<Func<Address, bool>> predicate);
        Task<ICollection<Address>> GetSelected(List<string> ids);
        Task<ICollection<Address>> GetSelected(Expression<Func<Address, bool>> predicate);
        Task<ICollection<Address>> GetAll();
    }
}
