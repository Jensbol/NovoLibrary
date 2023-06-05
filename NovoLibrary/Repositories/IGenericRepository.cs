using Microsoft.EntityFrameworkCore;
using NovoLibrary.Data;

namespace NovoLibrary.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity>? GetById(int id);
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);

    }
}
