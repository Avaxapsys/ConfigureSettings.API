using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Repository
{
    public interface IEnvironventRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetByAplicationNameAsync(string name);
    }
}
