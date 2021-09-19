using ConfigureSettings.API.Context;
using ConfigureSettings.API.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add(Aplications entity)
        {
            _settingsContext.Set<Aplications>().Add(entity);
            //_settingsContext.Entry(entity.Settings).State = EntityState.Detached;
            _settingsContext.SaveChanges();
        }

        public void Delete(Aplications entity)
        {
            _settingsContext.Aplications.Remove(entity);
            _settingsContext.SaveChanges();
        }

        public Aplications Get(int id)
        {
            return _settingsContext.Aplications
                  .FirstOrDefault(e => e.AplicationId == id);
        }

        public IEnumerable<Aplications> GetAll()
        {
            return _settingsContext.Aplications.ToList();
        }

        public void Update(Aplications aplications, Aplications entity)
        {
            aplications.Name = entity.Name;
            _settingsContext.SaveChanges();
        }
    }
}
