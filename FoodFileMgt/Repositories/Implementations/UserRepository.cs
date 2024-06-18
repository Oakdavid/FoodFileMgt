using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<User> Get(string id)
        {
            var user = await _context.Set<User>()
                .Include(a => a.Profile)
                .Include(a => a.Role)
                .SingleOrDefaultAsync(a => a.Id == id);
            return user;
        }

        public async Task<User> Get(Expression<Func<User, bool>> predicate)
        {
            var user = await _context.Set<User>()
                .Include(a => a.Profile)
                .Include(a => a.Role)
                .SingleOrDefaultAsync(predicate);
            return user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var user = await _context.Set<User>()
                .Include(a => a.Profile)
                .Include(a => a.Role)
                .ToListAsync();
            return user;
        }

        public async Task<ICollection<User>> GetSelected(List<string> ids)
        {
            var user = await _context.Set<User>()
                .Include(a => a.Profile)
                .Include(a => a.Role)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return user;
        }

        public async Task<ICollection<User>> GetSelected(Expression<Func<User, bool>> predicate)
        {
            var user = await _context.Set<User>()
                .Include(a => a.Profile)
                .Include(a => a.Role)
                .Where(predicate).ToListAsync();
            return user;
        }
    }
}
