using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Customer> Get(string id)
        {
            var customer = await _context.Set<Customer>()
                .Include(a => a.Orders)
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);
            return customer;
        }

        public async Task<Customer> Get(Expression<Func<Customer, bool>> predicate)
        {
            var customer = await _context.Set<Customer>()
                .Include(a => a.Orders)
                .Include(a => a.User)
                .SingleOrDefaultAsync(predicate);
            return customer;
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            var customer = await _context.Set<Customer>()
                .Include(a => a.Orders)
                .Include(a => a.User)
                .ToListAsync();
            return customer;
        }

        public async Task<ICollection<Customer>> GetSelected(List<string> ids)
        {
            var customer = await _context.Set<Customer>()
                .Include(a => a.Orders)
                .Include(a => a.User)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return customer;
        }

        public async Task<ICollection<Customer>> GetSelected(Expression<Func<Customer, bool>> predicate)
        {
            var customer = await _context.Set<Customer>()
                .Include(a => a.Orders)
                .Include(a => a.User)
                .Where(predicate).ToListAsync();
            return customer;
        }
    }
}
