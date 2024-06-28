using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.Common;
using MLS.Application.Exceptions;
using MLS.Domain.Common;
using MLS.Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace MLS.Persistence.Repository.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MatLidStoreDatabaseContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(MatLidStoreDatabaseContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            // Config soft deletion
            //entity.IsDeleted = true;
            //_context.Set<T>().Update(entity);
            //await _context.SaveChangesAsync();

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            //return await _entities.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync();
            IQueryable<T> query = _entities.Where(e => !e.IsDeleted);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (entity is null)
            {
                throw new NotFoundException(typeof(T).ToString(), id);
            }

            return entity;
            //var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            //if (entity is null)
            //{
            //    throw new NotFoundException(typeof(T).ToString(), id);
            //}

            //return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}