using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodFileMgt.Repositories.Implementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Address> Get(string id)
        {
            var address =  await _context.Set<Address>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .SingleOrDefaultAsync(a => a.Id == id);
            return address;
        }

        public async Task<Address> Get(Expression<Func<Address, bool>> predicate)
        {
            var address = await _context.Set<Address>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .SingleOrDefaultAsync(predicate);
            return address;
        }

        public async Task<ICollection<Address>> GetAll()
        {
            var addresses = await _context.Set<Address>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .ToListAsync();
            return addresses;
        }

        public async Task<ICollection<Address>> GetSelected(List<string> ids)
        {
            var addresses = await _context.Set<Address>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .Where(a => ids.Contains(a.Id)).ToListAsync();
            return addresses;
        }

        public async Task<ICollection<Address>> GetSelected(Expression<Func<Address, bool>> predicate)
        {
            var addresses = await _context.Set<Address>()
                .Include(a => a.Branch)
                .Include(a => a.User)
                .Where(predicate).ToListAsync();
            return addresses;
        }
    }
}
