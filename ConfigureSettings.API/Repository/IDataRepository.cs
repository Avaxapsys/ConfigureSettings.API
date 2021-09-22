using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity dbEntity, TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
