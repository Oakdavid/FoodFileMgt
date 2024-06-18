using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Category> Get(string id)
        {
            var category = await _context.Set<Category>()
                .Include(a => a.Foods)
                .SingleOrDefaultAsync(a => a.Id == id);
            return category;
        }

        public async Task<Category> Get(Expression<Func<Category, bool>> predicate)
        {
            var category = await _context.Set<Category>()
                .Include(a => a.Foods)
                .SingleOrDefaultAsync(predicate);
            return category;
        }

        public async Task<ICollection<Category>> GetAll()
        {
            var category = await _context.Set<Category>()
                .Include(a => a.Foods)
                .ToListAsync();
            return category;
        }

        public async Task<ICollection<Category>> GetSelected(List<string> ids)
        {
            var category = await _context.Set<Category>()
                .Include(a => a.Foods)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return category;
        }

        public async Task<ICollection<Category>> GetSelected(Expression<Func<Category, bool>> predicate)
        {
            var category = await _context.Set<Category>()
                .Include(a => a.Foods)
                .Where(predicate).ToListAsync();
            return category;
        }
    }
}
