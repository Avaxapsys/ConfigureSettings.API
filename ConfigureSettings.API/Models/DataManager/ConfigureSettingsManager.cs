using ConfigureSettings.API.Context;
using ConfigureSettings.API.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ConfigureSettings.API.Models.DataManager
{
    public class ConfigureSettingsManager : IDataRepository<Settings>
    {
        readonly SettingsContext _settingsContext;
        public ConfigureSettingsManager(SettingsContext context)
        {
            _settingsContext = context;
        }
        public void Add(Settings entity)
        {
            _settingsContext.Settings.Add(entity);
            _settingsContext.SaveChanges();
        }

        public void Delete(Settings entity)
        {
            _settingsContext.Settings.Remove(entity);
            _settingsContext.SaveChanges();
        }

        public Settings Get(int id)
        {
            return _settingsContext.Settings
                  .FirstOrDefault(e => e.SettingId == id);
        }

        public IEnumerable<Settings> GetAll()
        {
            return _settingsContext.Settings.ToList();
        }

        public void Update(Settings settings, Settings entity)
        {
            settings.Key = entity.Key;
            settings.Value = entity.Value;
        }
    }
}
