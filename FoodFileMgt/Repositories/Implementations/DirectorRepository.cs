using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class DirectorRepository : BaseRepository<Director>,IDirectorRepository
    {
        public DirectorRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Director> Get(string id)
        {
            var director = await _context.Set<Director>()
                .Include(a => a.Branch)

                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);
            return director;
        }

        public async Task<Director> Get(Expression<Func<Director, bool>> predicate)
        {
            var director = await _context.Set<Director>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .SingleOrDefaultAsync(predicate);
            return director;
        }

        public async Task<ICollection<Director>> GetAll()
        {
            var director = await _context.Set<Director>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .ToListAsync();
            return director;
        }

        public async Task<ICollection<Director>> GetSelected(List<string> ids)
        {
            var director = await _context.Set<Director>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return director;
        }

        public async Task<ICollection<Director>> GetSelected(Expression<Func<Director, bool>> predicate)
        {
            var director = await _context.Set<Director>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .Where(predicate).ToListAsync();
            return director;
        }
    }
}
