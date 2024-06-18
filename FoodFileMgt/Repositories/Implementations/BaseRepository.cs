using FoodFileMgt.Context;
using FoodFileMgt.Models.Entities;
using FoodFileMgt.Repositories.Interfaces;

namespace FoodFileMgt.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected FoodContext _context;
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
