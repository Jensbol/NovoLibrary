using Microsoft.EntityFrameworkCore;
using NovoLibrary.Data;
using System.Collections.Generic;

namespace NovoLibrary.Core.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal LibraryContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(LibraryContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity>? GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
