
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add entity
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Get all entities as IQueryable
        public IQueryable<T> AllIQueryable(CancellationToken cancellationToken = default)
        {
            return _context.Set<T>().AsQueryable();
        }

        // Get first entity
        public async Task<T> FirstAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstAsync(cancellationToken);
        }

        // Get first or default
        public async Task<T> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);
        }

        // Get all entities
        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        // Get entity by ID (assumes primary key is long)
        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        // Update entity
        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        // Delete entity permanently
        public async Task<bool> PermanentDeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        // Delete by Id permanently
        public async Task<bool> PermanentDeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        // Count all entities
        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().CountAsync(cancellationToken);
        }

        // Get paged data
        public async Task<IReadOnlyList<T>> GetAllPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>()
                                 .Skip(recSkip)
                                 .Take(recTake)
                                 .ToListAsync(cancellationToken);
        }

        public Task<IReadOnlyList<T>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

 

        public Task<IReadOnlyList<T>> GetDeletedPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

     
    }
}
