using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {

        public FoodRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Food> Get(string id)
        {
            var food = await _context.Set<Food>()
                .Include(a => a.FoodBranches)
                .Include(a => a.CategoryId)
                .Include(a => a.FoodOrders)
                .ThenInclude(a => a.Order)
                .SingleOrDefaultAsync(a => a.Id == id);
            return food;
        }

        public async Task<Food> Get(Expression<Func<Food, bool>> predicate)
        {
            var food = await _context.Set<Food>()
                .Include(a => a.FoodBranches)
                .Include(a => a.CategoryId)
                .Include(a => a.FoodOrders)
                .ThenInclude(a => a.Order)
                .SingleOrDefaultAsync(predicate);
            return food;
        }

        public async Task<ICollection<Food>> GetAll()
        {
            var food = await _context.Set<Food>()
                .Include(a => a.FoodBranches)
                .Include(a => a.CategoryId)
                .Include(a => a.FoodOrders)
                .ThenInclude(a => a.Order)
                .ToListAsync();
            return food;
        }

        public async Task<ICollection<Food>> GetSelected(List<string> ids)
        {
            var food = await _context.Set<Food>()
                .Include(a => a.FoodBranches)
                .Include(a => a.CategoryId)
                .Include(a => a.FoodOrders)
                .ThenInclude(a => a.Order)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return food;
        }

        public async Task<ICollection<Food>> GetSelected(Expression<Func<Food, bool>> predicate)
        {
            var food = await _context.Set<Food>()
                .Include(a => a.FoodBranches)
                .Include(a => a.CategoryId)
                .Include(a => a.FoodOrders)
                .ThenInclude(a => a.Order)
                .Where(predicate).ToListAsync();
            return food;
        }
    }
}
