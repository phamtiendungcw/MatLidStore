using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.Common;
using MLS.Application.Exceptions;
using MLS.Domain.Common;
using MLS.Persistence.DatabaseContext;

namespace MLS.Persistence.Repository.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MatLidStoreDatabaseContext _context;

        public GenericRepository(MatLidStoreDatabaseContext context)
        {
            _context = context;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new NotFoundException(typeof(T).ToString(), id);
            }

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}