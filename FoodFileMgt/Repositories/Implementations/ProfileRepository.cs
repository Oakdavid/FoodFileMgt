using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class ProfileRepository : BaseRepository<Profile> ,IProfileRepository
    {
        public ProfileRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Profile> Get(string id)
        {
            var profile = await _context.Set<Profile>()
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);
            return profile;
        }

        public async Task<Profile> Get(Expression<Func<Profile, bool>> predicate)
        {
            var profile = await _context.Set<Profile>()
                .Include(a => a.User)
                .SingleOrDefaultAsync(predicate);
            return profile;
        }

        public async Task<ICollection<Profile>> GetAll()
        {
            var profile = await _context.Set<Profile>()
                .Include(a => a.User)
                .ToListAsync();
            return profile;
        }

        public async Task<ICollection<Profile>> GetSelected(List<string> ids)
        {
            var profile = await _context.Set<Profile>()
                .Include(a => a.User)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return profile;
        }

        public async Task<ICollection<Profile>> GetSelected(Expression<Func<Profile, bool>> predicate)
        {
            var profile = await _context.Set<Profile>()
                .Include(a => a.User)
                .Where(predicate).ToListAsync();
            return profile;
        }
    }
}
