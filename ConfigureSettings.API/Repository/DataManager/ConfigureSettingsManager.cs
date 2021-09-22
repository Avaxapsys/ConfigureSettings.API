using ConfigureSettings.API.Context;
using ConfigureSettings.API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Models.DataManager
{
    public class ConfigureSettingsManager : IDataRepository<Settings>, IEnvironventRepository<Settings>
    {
        readonly SettingsContext _settingsContext;
        public ConfigureSettingsManager(SettingsContext context)
        {
            _settingsContext = context;
        }
        public async Task AddAsync(Settings entity)
        {
            _settingsContext.Settings.Add(entity);
            await _settingsContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Settings entity)
        {
            _settingsContext.Settings.Remove(entity);
           await _settingsContext.SaveChangesAsync();
        }

        public async Task<Settings> GetByIdAsync(int id)
        {
            return await _settingsContext.Settings
                  .FirstOrDefaultAsync(e => e.SettingId == id);
        }

        public async Task<IEnumerable<Settings>> GetByAplicationNameAsync(string name)
        {
            Aplications aplicationId = await _settingsContext.Aplications
                  .FirstOrDefaultAsync(e => e.Name == name);

           return await _settingsContext.Settings
                .Where(a => a.AplicationId == aplicationId.AplicationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Settings>> GetAllAsync() => await _settingsContext.Settings.ToListAsync();

        public async Task UpdateAsync(Settings settings, Settings entity)
        {
            settings.Key = entity.Key;
            settings.Value = entity.Value;
            await _settingsContext.SaveChangesAsync();
        }
    }
}
