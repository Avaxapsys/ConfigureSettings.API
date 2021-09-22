using ConfigureSettings.API.Context;
using ConfigureSettings.API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Models.DataManager
{
    public class AplicationManager : IDataRepository<Aplications>
    {
        readonly SettingsContext _settingsContext;
        public AplicationManager(SettingsContext context)
        {
            _settingsContext = context;
        }
        public async Task AddAsync(Aplications entity)
        {
            _settingsContext.Set<Aplications>().Add(entity);
            await _settingsContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Aplications entity)
        {
            _settingsContext.Aplications.Remove(entity);
           await _settingsContext.SaveChangesAsync();
        }

        public async Task<Aplications> GetByIdAsync(int id)
        {
          return await _settingsContext.Aplications
                  .FirstOrDefaultAsync(e => e.AplicationId == id);
        }

        public async Task<IEnumerable<Aplications>> GetAllAsync() => await _settingsContext.Aplications.ToListAsync();

        public async Task UpdateAsync(Aplications aplications, Aplications entity)
        {
            aplications.Name = entity.Name;
            await _settingsContext.SaveChangesAsync();
        }
    }
}
