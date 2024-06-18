using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class BranchRepository:BaseRepository<Branch> , IBranchRepository
    {

        public BranchRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Branch> Get(string id)
        {
            var branch = await _context.Set<Branch>()
                .Include(a => a.FoodBranches)
                .Include(a => a.Company)
                .Include(a => a.Director)
                .ThenInclude(a => a.User)
                .ThenInclude(a => a.Profile)
                .SingleOrDefaultAsync(a => a.Id == id);
            return branch;
        }

        public async Task<Branch> Get(Expression<Func<Branch, bool>> predicate)
        {
            var branch = await _context.Set<Branch>()
                .Include(a => a.FoodBranches)
                .Include(a => a.Company)
                .Include(a => a.Director)
                .SingleOrDefaultAsync(predicate);
            return branch;
        }

        public async Task<ICollection<Branch>> GetAll()
        {
            var branch = await _context.Set<Branch>()
                .Include(a => a.FoodBranches)
                .Include(a => a.Company)
                .Include(a => a.Director)
                .ToListAsync();
            return branch;
        }

        public async Task<ICollection<Branch>> GetSelected(List<string> ids)
        {
            var branches = await _context.Set<Branch>()
                .Include(a => a.FoodBranches)
                .Include(a => a.Company)
                .Include(a => a.Director)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return branches;
        }

        public async Task<ICollection<Branch>> GetSelected(Expression<Func<Branch, bool>> predicate)
        {
            var branch = await _context.Set<Branch>()
                .Include(a => a.FoodBranches)
                .Include(a => a.Company)
                .Include(a => a.Director)
                .Where(predicate).ToListAsync();
            return branch;
        }
    }
}
