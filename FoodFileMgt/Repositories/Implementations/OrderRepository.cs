using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Order> Get(string id)
        {
            var order = await _context.Set<Order>()
                .Include(a => a.FoodOrders)
                .Include(a => a.Customer)
                .SingleOrDefaultAsync(a => a.Id == id);
            return order;
        }

        public async Task<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            var order = await _context.Set<Order>()
                .Include(a => a.FoodOrders)
                .Include(a => a.Customer)
                .SingleOrDefaultAsync(predicate);
            return order;
        }

        public async Task<ICollection<Order>> GetAll()
        {
            var order = await _context.Set<Order>()
                .Include(a => a.FoodOrders)
                .Include(a => a.Customer)
                .ToListAsync();
            return order;
        }

        public async Task<ICollection<Order>> GetSelected(List<string> ids)
        {
            var order = await _context.Set<Order>()
                .Include(a => a.FoodOrders).ThenInclude(a => a.Food)
                .Include(a => a.Customer).ThenInclude(a => a.User).ThenInclude(a => a.Profile)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return order;
        }

        public async Task<ICollection<Order>> GetSelected(Expression<Func<Order, bool>> predicate)
        {
            var order = await _context.Set<Order>()
                .Include(a => a.FoodOrders)
                .Include(a => a.Customer)
                .Where(predicate).ToListAsync();
            return order;
        }
    }
}
