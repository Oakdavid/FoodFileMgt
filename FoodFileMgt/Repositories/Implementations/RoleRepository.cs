using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role> ,IRoleRepository
    {

        public RoleRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Role> Get(string id)
        {
            var role = await _context.Set<Role>()
                .Include(a => a.Users)
                .SingleOrDefaultAsync(a => a.Id == id);
            return role;
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> predicate)
        {
            var role = await _context.Set<Role>()
                .Include(a => a.Users)
                .SingleOrDefaultAsync(predicate);
            return role;
        }

        public async Task<ICollection<Role>> GetAll()
        {
            var role = await _context.Set<Role>()
                .Include(a => a.Users)
                .ToListAsync();
            return role;
        }

        public async Task<ICollection<Role>> GetSelected(List<string> ids)
        {
            var role = await _context.Set<Role>()
                .Include(a => a.Users)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return role;
        }

        public async Task<ICollection<Role>> GetSelected(Expression<Func<Role, bool>> predicate)
        {
            var role = await _context.Set<Role>()
                .Include(a => a.Users)
                .Where(predicate).ToListAsync();
            return role;
        }
    }
}
