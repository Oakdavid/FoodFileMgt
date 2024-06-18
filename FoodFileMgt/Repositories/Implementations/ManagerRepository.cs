using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class ManagerRepository : BaseRepository<Manager>,IManagerRepository
    {
        public ManagerRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Manager> Get(string id)
        {
            var manager = await _context.Set<Manager>()
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);
            return manager;
        }

        public async Task<Manager> Get(Expression<Func<Manager, bool>> predicate)
        {
            var manager = await _context.Set<Manager>()
                .Include(a => a.User)
                .SingleOrDefaultAsync(predicate);
            return manager;
        }

        public async Task<ICollection<Manager>> GetAll()
        {
            var manager = await _context.Set<Manager>()

                .Include(a => a.User)
                .ToListAsync();
            return manager;
        }

        public async Task<ICollection<Manager>> GetSelected(List<string> ids)
        {
            var manager = await _context.Set<Manager>().Include(a => a.User)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return manager;
        }

        public async Task<ICollection<Manager>> GetSelected(Expression<Func<Manager, bool>> predicate)
        {
            var manager = await _context.Set<Manager>()
                .Include(a => a.User)
                .Where(predicate).ToListAsync();
            return manager;
        }

    }
}
