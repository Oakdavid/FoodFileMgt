using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Company> Get(string id)
        {
            var company = await _context.Set<Company>()
                .Include(a => a.Branches)
                .Include(a => a.Manager)
                .SingleOrDefaultAsync(a => a.Id == id);
            return company;
        }

        public async Task<Company> Get(Expression<Func<Company, bool>> predicate)
        {
            var company = await _context.Set<Company>()
                .Include(a => a.Branches)
                .Include(a => a.Manager)
                .SingleOrDefaultAsync(predicate);
            return company;
        }

        public async Task<ICollection<Company>> GetAll()
        {
            var company = await _context.Set<Company>()
                .Include(a => a.Branches)
                .Include(a => a.Manager)
                .ToListAsync();
            return company;
        }

        public async Task<ICollection<Company>> GetSelected(List<string> ids)
        {
            var companies = await _context.Set<Company>()
                .Include(a => a.Branches)
                .Include(a => a.Manager)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return companies;
        }

        public async Task<ICollection<Company>> GetSelected(Expression<Func<Company, bool>> predicate)
        {
            var companies = await _context.Set<Company>()
                .Include(a => a.Branches)
                .Include(a => a.Manager)
                .Where(predicate).ToListAsync();
            return companies;
        }
    }
}
